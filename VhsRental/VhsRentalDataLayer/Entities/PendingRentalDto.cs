namespace VhsRentalDataLayer.Entities;

public class PendingRentalDto
{
    public int CassetteId { get; }
    public decimal DefaultAmount { get; }
    public decimal ActualAmount { get; }

    public PendingRentalDto(int cassetteId, decimal defaultAmount, decimal actualAmount)
    {
        CassetteId = cassetteId;
        DefaultAmount = defaultAmount;
        ActualAmount = actualAmount;
    }
}