namespace VhsRentalBusinessLayer;

public class PropertyVisualizerAttribute : Attribute
{
    public int Order { get; }
    public string Label { get; }

    public PropertyVisualizerAttribute(int order, string label)
    {
        Order = order;
        Label = label;
    }
}
