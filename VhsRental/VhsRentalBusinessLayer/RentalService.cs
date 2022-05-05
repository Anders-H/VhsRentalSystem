namespace VhsRentalBusinessLayer;

public class RentalService
{
    private readonly int _customerId;
    private readonly int _staffId;
    private readonly DateTime _eventTime;
    private VhsRentalDataLayer.RentalService? _rentalService;

    public RentalService(int customerId, int staffId)
    {
        _customerId = customerId;
        _staffId = staffId;
        _eventTime = DateTime.Now;
    }

    public int TransactionId =>
        _rentalService?.TransactionId ?? 0;

    public RentalServiceOpenRentalEventResult CreateRentalEventTransaction()
    {
        _rentalService = new VhsRentalDataLayer.RentalService(_customerId, _staffId, _eventTime);

        var result = _rentalService.OpenTransaction();

        switch (result)
        {
            case VhsRentalDataLayer.RentalServiceResult.Success:
                return RentalServiceOpenRentalEventResult.Success;
            case VhsRentalDataLayer.RentalServiceResult.CustomerNotFound:
                return RentalServiceOpenRentalEventResult.CustomerNotFound;
            case VhsRentalDataLayer.RentalServiceResult.CustomerBlocked:
                return RentalServiceOpenRentalEventResult.CustomerBlocked;
            default:
                return RentalServiceOpenRentalEventResult.UnexpectedResult;
        }
    }

    public RentalServiceResult AddRentalToTransaction(int cassetteId, decimal amount, string description)
    {
        if (TransactionId <= 0)
            throw new SystemException();

        var result = _rentalService!.AddRentalToTransaction(cassetteId, amount, description);

        switch (result)
        {
            case VhsRentalDataLayer.RentalServiceResult.Success:
                return RentalServiceResult.Success;
            case VhsRentalDataLayer.RentalServiceResult.CustomerBlocked:
                return RentalServiceResult.CustomerBlocked;
            case VhsRentalDataLayer.RentalServiceResult.CustomerNotFound:
                return RentalServiceResult.CustomerNotFound;
            case VhsRentalDataLayer.RentalServiceResult.CassetteInactive:
                return RentalServiceResult.CassetteInactive;
            case VhsRentalDataLayer.RentalServiceResult.CassetteNotFound:
                return RentalServiceResult.CassetteNotFound;
            case VhsRentalDataLayer.RentalServiceResult.MovieOrCompanyNotFound:
                return RentalServiceResult.MovieOrCompanyNotFound;
            case VhsRentalDataLayer.RentalServiceResult.StaffInactiveOrNotFound:
                return RentalServiceResult.StaffInactiveOrNotFound;
            default:
                return RentalServiceResult.UnexpectedResult;
        }
    }

    public void CloseTransaction(bool canceled)
    {
        try
        {
            _rentalService!.CloseTransaction(canceled);
        }
        catch
        {
            // ignored
        }
    }

    public static void ReturnCassette(int cassetteId, int staffId, string description)
    {
        try
        {
            VhsRentalDataLayer.RentalService.ReturnCassette(cassetteId, staffId, description);
        }
        catch
        {
            // ignored
        }
    }
}