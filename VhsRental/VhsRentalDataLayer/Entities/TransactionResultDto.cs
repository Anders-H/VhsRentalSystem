namespace VhsRentalDataLayer.Entities;

public class TransactionResultDto
{
    public int Id { get; }
    public string Message { get; }

    public TransactionResultDto(int id, string message)
    {
        Id = id;
        Message = message;
    }
}