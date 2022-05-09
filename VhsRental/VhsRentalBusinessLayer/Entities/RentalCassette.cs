namespace VhsRentalBusinessLayer.Entities;

public class RentalCassette
{
    public int CassetteId { get; }
    public decimal Amount { get; }
    public string Description { get; set; }

    public RentalCassette(int cassetteId, decimal amount, string description)
    {
        CassetteId = cassetteId;
        Amount = amount;
        Description = description;
    }
}