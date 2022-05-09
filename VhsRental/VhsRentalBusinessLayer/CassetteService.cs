using VhsRentalBusinessLayer.Entities;

namespace VhsRentalBusinessLayer;

public class CassetteService : IDisposable
{
    private readonly VhsRentalDataLayer.CassetteService _cassetteService;

    public CassetteService()
    {
        _cassetteService = new VhsRentalDataLayer.CassetteService();
    }

    public bool CassetteIsOut(int cassetteId)
    {
        return _cassetteService.CassetteIsOut(cassetteId);
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
    {
        _cassetteService.ReturnCassette(cassetteId, staffId, description);
    }

    public RentalCassette? GetCassetteForRental(int cassetteId)
    {
        var result = _cassetteService.GetCassetteForRental(cassetteId);

        if (result == null)
            return null;

        return new RentalCassette(result.CassetteId, result.Amount, "");
    }

    public void Dispose()
    {
        _cassetteService.Dispose();
    }
}