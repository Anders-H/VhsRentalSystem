using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer;

public class CassetteService : IDisposable
{
    private readonly SqlConnection _connection;

    public CassetteService()
    {
        _connection = new SqlConnection(Settings.ConnectionString);
        _connection.Open();
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
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