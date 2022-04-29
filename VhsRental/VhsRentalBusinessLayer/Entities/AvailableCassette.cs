namespace VhsRentalBusinessLayer.Entities;

public class AvailableCassette
{
    public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal CustomerPrice { get; set; }
    public int NumberOfCopies { get; set; }

    public AvailableCassette() : this(0, "", 0, 0, 0)
    {
    }

    public AvailableCassette(int id, string title, short year, decimal customerPrice, int numberOfCopies)
    {
        Id = id;
        Title = title;
        Year = year;
        CustomerPrice = customerPrice;
        NumberOfCopies = numberOfCopies;
    }

    private AvailableCassette(VhsRentalDataLayer.Entities.AvailableCassette data)
    {
        Id = data.Id;
        Title = data.Title;
        Year = data.Year;
        CustomerPrice = data.CustomerPrice;
        NumberOfCopies = data.NumberOfCopies;
    }

    public static List<AvailableCassette> GetAvailableCassettesFromMovieEan(decimal ean)
    {
        var result = new List<AvailableCassette>();

        try
        {
            var sourceList = VhsRentalDataLayer.Entities.AvailableCassette.GetAvailableCassettesFromMovieEan(ean);
            result.AddRange(sourceList.Select(s => new AvailableCassette(s)));
        }
        catch
        {
            // ignored
        }

        return result;
    }

    public static List<AvailableCassette> GetCassetteFromEan(decimal ean)
    {
        var result = new List<AvailableCassette>();

        try
        {
            var sourceList = VhsRentalDataLayer.Entities.AvailableCassette.GetCassetteFromEan(ean);
            result.AddRange(sourceList.Select(s => new AvailableCassette(s)));
        }
        catch
        {
            // ignored
        }

        return result;
    }

    public static AvailableCassette? GetUnavailableCassettesFromMovieEan(decimal ean)
    {
        try
        {
            var result = VhsRentalDataLayer.Entities.AvailableCassette.GetUnavailableCassettesFromMovieEan(ean);
            
            return result == null
                ? null
                : new AvailableCassette(result);
        }
        catch
        {
            return null;
        }
    }

    public override string ToString() =>
        $"{Id}: {Title} ({Year:0000}), price: {CustomerPrice:n2}, {NumberOfCopies} copies";
}