using System.Data;
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
        using var cmd = new SqlCommand("dbo.IsCassetteOut", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);
        return (int)cmd.ExecuteScalar() > 0;
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
    {
        using var cmd = new SqlCommand("dbo.ReturnCassette", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);
        cmd.Parameters.AddWithValue("@StaffID", staffId);
        cmd.Parameters.AddWithValue("@ID", cassetteId);
        cmd.ExecuteNonQuery();
    }

    public RentalCassette? GetCassetteForRental(int cassetteId)
    {
        //dbo.SuggestPrice
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