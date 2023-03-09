namespace VhsRentalDataLayer.Entities;

public class RentalCassetteDto
{
    public int CassetteId { get; }
    public decimal Amount { get; }

    public RentalCassetteDto(int cassetteId, decimal amount)
    {
        CassetteId = cassetteId;
        Amount = amount;
    }
}