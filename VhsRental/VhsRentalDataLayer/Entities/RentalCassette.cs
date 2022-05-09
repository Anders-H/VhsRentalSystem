namespace VhsRentalDataLayer.Entities;

public class RentalCassette
{
    public int CassetteId { get; }
    public decimal Amount { get; }

    public RentalCassette(int cassetteId, decimal amount)
    {
        CassetteId = cassetteId;
        Amount = amount;
    }
}