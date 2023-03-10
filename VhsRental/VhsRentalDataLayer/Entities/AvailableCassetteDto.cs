using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class AvailableCassetteDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal CustomerPrice { get; set; }
    public int NumberOfCopies { get; set; }

    public AvailableCassetteDto(int id, string title, short year, decimal customerPrice, int numberOfCopies)
    {
        Id = id;
        Title = title;
        Year = year;
        CustomerPrice = customerPrice;
        NumberOfCopies = numberOfCopies;
    }

    public static List<AvailableCassetteDto> GetAvailableCassettesFromMovieEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetAvailableCassettesFromMovieEAN");

    public static List<AvailableCassetteDto> GetCassetteFromEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetCassetteFromEAN");

    public static AvailableCassetteDto? GetUnavailableCassettesFromMovieEan(decimal ean) =>
        GetCassettes(ean, "dbo.GetUnavailableCassettesFromMovieEAN").FirstOrDefault();

    private static List<AvailableCassetteDto> GetCassettes(decimal ean, string proc)
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
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

        var result = new List<AvailableCassetteDto>();

        while (r.Read())
            result.Add(
                new AvailableCassetteDto(
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