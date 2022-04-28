namespace VhsRental;

public class ControlTagData
{
    public bool Enabled { get; set; }
    public int EntityId { get; set; }

    public ControlTagData()
    {
        Enabled = true;
        EntityId = 0;
    }
}