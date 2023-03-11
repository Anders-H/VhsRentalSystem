using VhsRentalBusinessLayer.Entities;

namespace VhsRentalBusinessLayer;

public class CassetteService : IDisposable
{
    private readonly VhsRentalDataLayer.CassetteDataService _cassetteDataService;

    public CassetteService()
    {
        _cassetteDataService = new VhsRentalDataLayer.CassetteDataService();
    }

    public bool CassetteIsOut(int cassetteId)
    {
        return _cassetteDataService.CassetteIsOut(cassetteId);
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
    {
        _cassetteDataService.ReturnCassette(cassetteId, staffId, description);
    }

    public RentalCassette GetCassetteForRental(int cassetteId)
    {
        var result = _cassetteDataService.GetCassetteForRental(cassetteId);

        return new RentalCassette(result.CassetteId, result.Amount, "");
    }

    public CassetteBasicInformation? GetBasicCassetteInformation(int cassetteId)
    {
        var result = _cassetteDataService.GetBasicCassetteInformation(cassetteId);

        return result == null
            ? null
            : new CassetteBasicInformation(result);
    }

    public List<int> GetAllCassetteIds() =>
        _cassetteDataService.GetAllCassetteIds();

    public bool AssignEanToCassette(int id, decimal ean) =>
        _cassetteDataService.AssignEanToCassette(id, ean);

    public void Dispose()
    {
        _cassetteDataService.Dispose();
    }
}