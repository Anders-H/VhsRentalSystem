namespace VhsRentalBusinessLayer.Entities;

public class RentalCassette
{
    public int CassetteId { get; }
    public decimal DefaultPrice { get; }
    public decimal ActualPrice { get; set; }
    public string Description { get; set; }

    public RentalCassette(int cassetteId, decimal defaultPrice, decimal actualPrice, string description)
    {
        CassetteId = cassetteId;
        DefaultPrice = defaultPrice;
        ActualPrice = actualPrice;
        Description = description;
    }
}