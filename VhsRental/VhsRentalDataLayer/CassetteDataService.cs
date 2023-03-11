using System.Data;
using Microsoft.Data.SqlClient;
using VhsRentalDataLayer.Entities;

namespace VhsRentalDataLayer;

public class CassetteDataService : IDisposable
{
    private readonly SqlConnection _connection;

    public CassetteDataService()
    {
        _connection = new SqlConnection(DataSettings.ConnectionString);
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

    public RentalCassetteDto GetCassetteForRental(int cassetteId)
    {
        using var cmd = new SqlCommand("dbo.SuggestPrice", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CassetteID", cassetteId);
        var price = (decimal)cmd.ExecuteScalar();
        return new RentalCassetteDto(cassetteId, price);
    }

    public CassetteBasicInformationDto? GetBasicCassetteInformation(int cassetteId)
    {
        using var cmd = new SqlCommand("dbo.GetBasicCassetteInformation", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);

        CassetteBasicInformationDto? result = null;

        var r = cmd.ExecuteReader();
        if (r.Read())
            result = new CassetteBasicInformationDto(
                r.GetInt32(r.GetOrdinal("ID")),
                r.GetDecimal(r.GetOrdinal("MovieEAN")),
                r.GetDecimal(r.GetOrdinal("CassetteEAN")),
                r.GetString(r.GetOrdinal("Title")),
                r.GetInt16(r.GetOrdinal("Year"))
            );

        r.Close();

        return result;
    }

    public List<int> GetAllCassetteIds()
    {
        var result = new List<int>();
        using var cmd = new SqlCommand("SELECT ID FROM dbo.Cassette", _connection);
        var r = cmd.ExecuteReader();
        while (r.Read())
            result.Add(r.GetInt32(0));
        r.Close();
        return result;
    }

    public bool AssignEanToCassette(int id, decimal ean)
    {
        using var cmd = new SqlCommand("dbo.AssignEanToCassette", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@EAN", ean);
        return (int)cmd.ExecuteScalar() > 0;
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