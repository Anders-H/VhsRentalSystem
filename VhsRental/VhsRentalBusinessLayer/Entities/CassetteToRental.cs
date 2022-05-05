namespace VhsRentalBusinessLayer.Entities;

public class CassetteToRental
{
    public int CassetteId { get; }
    public decimal Amount { get; }
    public string Description { get; set; }

    public CassetteToRental(int cassetteId, decimal amount, string description)
    {
        CassetteId = cassetteId;
        Amount = amount;
        Description = description;
    }
}