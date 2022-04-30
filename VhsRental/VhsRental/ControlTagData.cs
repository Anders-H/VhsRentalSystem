namespace VhsRental;

public class ControlTagData
{
    public string OriginalText { get; set; }
    public bool Enabled { get; set; }
    public int EntityId { get; set; }
    public decimal Money { get; set; }

    public ControlTagData()
    {
        OriginalText = "";
        Enabled = true;
        EntityId = 0;
        Money = 0m;
    }

    public void Clear()
    {
        OriginalText = "";
        Enabled = true;
        EntityId = 0;
        Money = 0m;
    }
}