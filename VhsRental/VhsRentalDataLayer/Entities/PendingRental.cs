namespace VhsRentalDataLayer.Entities;

public class PendingRental
{
    public int CassetteId { get; }
    public decimal Amount { get; }

    public PendingRental(int cassetteId, decimal amount)
    {
        CassetteId = cassetteId;
        Amount = amount;
    }
}