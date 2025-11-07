namespace VhsRental.Screens;

public struct CassetteIdAndGivenPrice
{
    public int CassetteId { get; }
    public decimal EnteredPrice { get; }

    public CassetteIdAndGivenPrice(int cassetteId, decimal enteredPrice)
    {
        CassetteId = cassetteId;
        EnteredPrice = enteredPrice;
    }
}