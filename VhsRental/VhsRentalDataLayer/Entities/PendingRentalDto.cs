namespace VhsRentalDataLayer.Entities;

public class PendingRentalDto
{
    public int CassetteId { get; }
    public decimal Amount { get; }

    public PendingRentalDto(int cassetteId, decimal amount)
    {
        CassetteId = cassetteId;
        Amount = amount;
    }
}