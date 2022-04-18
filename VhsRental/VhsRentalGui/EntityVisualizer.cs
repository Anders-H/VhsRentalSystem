using System.Reflection;
using VhsRentalBusinessLayer;

namespace VhsRentalGui;

public class EntityVisualizer : GuiObject
{
    private class Entity
    {
        private string Value { get; }
        public int SortOrder { get; }
        public string Label { get; }

        public Entity(int sortOrder, string label, string value)
        {
            SortOrder = sortOrder;
            Label = label;
            Value = value;
        }

        public void Write(int labelWidth, int valueWidth)
        {
            var l = Label;

            while (l.Length < labelWidth)
                l = $" {l}";

            if (l.Length > labelWidth)
                l = l.Substring(0, labelWidth);

            var v = Value;

            if (v.Length > valueWidth)
                v = v.Substring(0, valueWidth);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(l);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(": ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(v);
        }
    }

    private readonly object _object;

    public EntityVisualizer(object o)
    {
        _object = o;
    }

    public void Write()
    {
        var properties = _object.GetType().GetProperties();

        var result = new List<Entity>();

        foreach (PropertyInfo p in properties)
        {
            var attributes = p.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute is PropertyVisualizerAttribute a)
                {
                    var value = p.GetValue(_object)?.ToString() ?? "";

                    if (p.GetValue(_object) != null && p.GetValue(_object) is decimal)
                    {
                        var decimalValue = (decimal)p.GetValue(_object)!;
                        value = decimalValue.ToString("n2");
                    }

                    result.Add(new Entity(a.Order, a.Label, value));
                }
            }
        }

        var totalWidth = Console.WindowWidth;
        
        var requiredLabelWidth = result
            .Select(p => p.Label.Length)
            .Prepend(0)
            .Max();

        var maxAllowedLabelWidth = totalWidth / 3;

        requiredLabelWidth = maxAllowedLabelWidth > requiredLabelWidth
            ? requiredLabelWidth
            : maxAllowedLabelWidth;

        var valueWidth = totalWidth - requiredLabelWidth - 2;

        foreach (var r in result.OrderBy(x => x.SortOrder))
            r.Write(requiredLabelWidth, valueWidth);
    }
}