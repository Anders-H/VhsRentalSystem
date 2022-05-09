using Microsoft.Data.SqlClient;
using VhsRentalDataLayer.Entities;

namespace VhsRentalDataLayer;

public class CassetteService : IDisposable
{
    private readonly SqlConnection _connection;

    public CassetteService()
    {
        _connection = new SqlConnection(Settings.ConnectionString);
        _connection.Open();
    }

    public bool CassetteIsOut(int cassetteId)
    {
        // dbo.IsCassetteOut
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
    {

    }

    public RentalCassette? GetCassetteForRental(int cassetteId)
    {

    }

    public void Dispose()
    {
        try
        {
            _connection.Close();
        }
        catch
        {
            // ignored
        }

        try
        {
            _connection.Dispose();
        }
        catch
        {
            // ignored
        }
    }
}