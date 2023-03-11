using Microsoft.Data.SqlClient;
using System.Data;

namespace VhsRentalDataLayer.Entities;

public class MovieDto
{
    public static int RegisterMovie(decimal ean, string title, short year, int companyId, int cassetteCount)
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.RegisterMovie", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EAN", ean);
        cmd.Parameters.AddWithValue("@Title", title);
        cmd.Parameters.AddWithValue("@Year", year);
        cmd.Parameters.AddWithValue("@CompanyID", companyId);
        cmd.Parameters.AddWithValue("@CassetteCount", cassetteCount);
        var id = (int)cmd.ExecuteScalar();
        cn.Close();
        return id;
    }
}