using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class CustomerSearchResultEntity
{
    public int Id { get; }
    public string Name { get; }
    public string Ssn { get; }
    public bool IsBlocked { get; }
    public string LastMovieTitle { get; }
    public int TotalNumberOfRentals { get; }
    public int CassettesOutNow { get; }
    public DateTime? LastActivity { get; }

    public CustomerSearchResultEntity(int id, string name, string ssn, bool isBlocked, string lastMovieTitle, int totalNumberOfRentals, int cassettesOutNow, DateTime? lastActivity)
    {
        Id = id;
        Name = name;
        Ssn = ssn;
        IsBlocked = isBlocked;
        LastMovieTitle = lastMovieTitle;
        TotalNumberOfRentals = totalNumberOfRentals;
        CassettesOutNow = cassettesOutNow;
        LastActivity = lastActivity;
    }

    public static List<CustomerSearchResultEntity> Search(string s)
    {
        var result = new List<CustomerSearchResultEntity>();
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.SearchCustomer", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SearchString", s);
        var r = cmd.ExecuteReader();

        var idOrdinal = r.GetOrdinal("ID");
        var nameOrdinal = r.GetOrdinal("Name");
        var ssnOrdinal = r.GetOrdinal("Name");
        var isBlockedOrdinal = r.GetOrdinal("Name");
        var lastMovieTitleOrdinal = r.GetOrdinal("Name");
        var totalNumberOfRentalsOrdinal = r.GetOrdinal("Name");
        var cassettesOutNowOrdinal = r.GetOrdinal("Name");
        var lastActivityOrdinal = r.GetOrdinal("Name");

        while (r.Read())
            result.Add(
                new CustomerSearchResultEntity(
                    r.GetInt32(idOrdinal),
                    r.GetString(nameOrdinal),
                    r.GetString(ssnOrdinal),
                    r.GetBoolean(isBlockedOrdinal),
                    r.IsDBNull(lastMovieTitleOrdinal) ? "" : r.GetString(lastMovieTitleOrdinal),
                    r.IsDBNull(totalNumberOfRentalsOrdinal) ? 0 : r.GetInt32(totalNumberOfRentalsOrdinal),
                    r.IsDBNull(cassettesOutNowOrdinal) ? 0 : r.GetInt32(cassettesOutNowOrdinal),
                    r.IsDBNull(lastActivityOrdinal) ? null : r.GetDateTime(lastActivityOrdinal)
                )
            );

        r.Close();
        cn.Close();
        return result;
    }
}