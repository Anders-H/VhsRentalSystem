namespace VhsRentalBusinessLayer;

public class RentalService
{
    private readonly int _customerId;
    private readonly int _staffId;
    private readonly DateTime _eventTime;
    private VhsRentalDataLayer.RentalDataService? _rentalService;

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
        _rentalService = new VhsRentalDataLayer.RentalDataService(_customerId, _staffId, _eventTime);

        var result = _rentalService.OpenTransaction();

        switch (result)
        {
            case VhsRentalDataLayer.RentalDataServiceResult.Success:
                return RentalServiceOpenRentalEventResult.Success;
            case VhsRentalDataLayer.RentalDataServiceResult.CustomerNotFound:
                return RentalServiceOpenRentalEventResult.CustomerNotFound;
            case VhsRentalDataLayer.RentalDataServiceResult.CustomerBlocked:
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
            case VhsRentalDataLayer.RentalDataServiceResult.Success:
                return RentalServiceResult.Success;
            case VhsRentalDataLayer.RentalDataServiceResult.CustomerBlocked:
                return RentalServiceResult.CustomerBlocked;
            case VhsRentalDataLayer.RentalDataServiceResult.CustomerNotFound:
                return RentalServiceResult.CustomerNotFound;
            case VhsRentalDataLayer.RentalDataServiceResult.CassetteInactive:
                return RentalServiceResult.CassetteInactive;
            case VhsRentalDataLayer.RentalDataServiceResult.CassetteNotFound:
                return RentalServiceResult.CassetteNotFound;
            case VhsRentalDataLayer.RentalDataServiceResult.MovieOrCompanyNotFound:
                return RentalServiceResult.MovieOrCompanyNotFound;
            case VhsRentalDataLayer.RentalDataServiceResult.StaffInactiveOrNotFound:
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
            VhsRentalDataLayer.RentalDataService.ReturnCassette(cassetteId, staffId, description);
        }
        catch
        {
            // ignored
        }
    }
}