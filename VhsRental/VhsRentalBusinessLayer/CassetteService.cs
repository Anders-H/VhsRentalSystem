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

    public RentalCassette GetCassetteForRental(int cassetteId)
    {
        var result = _cassetteService.GetCassetteForRental(cassetteId);

        return new RentalCassette(result.CassetteId, result.Amount, "");
    }

    public CassetteBasicInformation? GetBasicCassetteInformation(int cassetteId)
    {
        var result = _cassetteService.GetBasicCassetteInformation(cassetteId);

        return result == null
            ? null
            : new CassetteBasicInformation(result);
    }

    public void Dispose()
    {
        _cassetteService.Dispose();
    }
}