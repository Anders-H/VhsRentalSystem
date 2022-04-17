using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace VhsRentalGui;

internal class EntityVisualizer : GuiObject
{
    private class Entity
    {
        private int SortOrder { get; }
        private string Label { get; }
        private string Value { get; }

        public Entity(int sortOrder, string label, string value)
        {
            SortOrder = sortOrder;
            Label = label;
            Value = value;
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
                if (attribute is PropertyVisualizerAttribute a)
                {
                    var value = p.GetValue(_object)?.ToString() ?? "";

                    if (p.GetValue(_object)?.GetType() is decimal)
                    {
                        value =
                    }

                    result.Add(new Entity(a.Order, a.Label, value));
                }
        }
    }
}