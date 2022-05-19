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
        return (bool)cmd.ExecuteScalar();
    }

    public void ReturnCassette(int cassetteId, int staffId, string description)
    {
        using var cmd = new SqlCommand("dbo.ReturnCassette", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);
        cmd.Parameters.AddWithValue("@StaffID", staffId);
        cmd.Parameters.AddWithValue("@Description", description);
        cmd.ExecuteNonQuery();
    }

    public RentalCassette GetCassetteForRental(int cassetteId)
    {
        using var cmd = new SqlCommand("dbo.SuggestPrice", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CassetteID", cassetteId);
        var price = (decimal)cmd.ExecuteScalar();
        return new RentalCassette(cassetteId, price);
    }

    public CassetteBasicInformation? GetBasicCassetteInformation(int cassetteId)
    {
        using var cmd = new SqlCommand("dbo.GetBasicCassetteInformation", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);

        CassetteBasicInformation? result = null;

        var r = cmd.ExecuteReader();
        if (r.Read())
            result = new CassetteBasicInformation(
                r.GetInt32(r.GetOrdinal("ID")),
                r.GetDecimal(r.GetOrdinal("MovieEAN")),
                r.GetDecimal(r.GetOrdinal("CassetteEAN")),
                r.GetString(r.GetOrdinal("Title")),
                r.GetInt16(r.GetOrdinal("Year"))
            );

        r.Close();

        return result;
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