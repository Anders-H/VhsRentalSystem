namespace VhsRentalDataLayer.Entities;

public class TransactionResult
{
    public int Id { get; }
    public string Message { get; }

    public TransactionResult(int id, string message)
    {
        Id = id;
        Message = message;
    }
}