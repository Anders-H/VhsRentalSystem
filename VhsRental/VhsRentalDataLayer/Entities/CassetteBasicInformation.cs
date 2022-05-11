namespace VhsRentalDataLayer.Entities;

public class CassetteBasicInformation
{
    public int Id { get; }
    public decimal MovieEan { get; }
    public decimal CassetteEan { get; }
    public string Title { get; }
    public short Year { get; }

    public CassetteBasicInformation(int id, decimal movieEan, decimal cassetteEan, string title, short year)
    {
        Id = id;
        MovieEan = movieEan;
        CassetteEan = cassetteEan;
        Title = title;
        Year = year;
    }
}