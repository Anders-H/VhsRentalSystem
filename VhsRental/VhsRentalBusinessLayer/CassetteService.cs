namespace VhsRentalBusinessLayer;

public class CassetteService : IDisposable
{
    private readonly VhsRentalDataLayer.CassetteService _cassetteService;

    public CassetteService()
    {
        _cassetteService = new VhsRentalDataLayer.CassetteService();
    }

    public void Dispose()
    {
        _cassetteService.Dispose();
    }
}