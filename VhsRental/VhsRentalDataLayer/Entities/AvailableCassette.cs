using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class AvailableCassette
{
    public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal CustomerPrice { get; set; }
    public int NumberOfCopies { get; set; }

    public AvailableCassette(int id, string title, short year, decimal customerPrice, int numberOfCopies)
    {
        Id = id;
        Title = title;
        Year = year;
        CustomerPrice = customerPrice;
        NumberOfCopies = numberOfCopies;
    }

    public static List<AvailableCassette> GetAvailableCassettesFromMovieEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetAvailableCassettesFromMovieEAN");

    public static List<AvailableCassette> GetCassetteFromEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetCassetteFromEAN");

    public static AvailableCassette? GetUnavailableCassettesFromMovieEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetUnavailableCassettesFromMovieEAN").FirstOrDefault();

    private static List<AvailableCassette> GetCassettes(decimal ean, string proc)
    {
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand(proc, cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EAN", ean);
        var r = cmd.ExecuteReader();
        var ordinalId = r.GetOrdinal("ID");
        var ordinalTitle = r.GetOrdinal("Title");
        var ordinalYear = r.GetOrdinal("Year");
        var ordinalCustomerPrice = r.GetOrdinal("CustomerPrice");
        var ordinalNumberOfCopies = r.GetOrdinal("NumberOfCopies");

        var result = new List<AvailableCassette>();

        while (r.Read())
            result.Add(
                new AvailableCassette(
                    r.GetInt32(ordinalId),
                    r.GetString(ordinalTitle),
                    r.GetInt16(ordinalYear),
                    r.GetDecimal(ordinalCustomerPrice),
                    r.GetInt16(ordinalNumberOfCopies)
                )
            );

        r.Close();
        cn.Close();

        return result;
    }
}