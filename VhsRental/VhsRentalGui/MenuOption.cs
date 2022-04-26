namespace VhsRentalGui;

public class MenuOption<T>
{
    public ConsoleKeyInfo Key { get; }
    public T Entity { get; }
    public string Name { get; }

    public MenuOption(ConsoleKeyInfo key, T entity, string name)
    {
        Key = key;
        Entity = entity;
        Name = name;
    }

    public static ConsoleKeyInfo GetKey(char keyChar, ConsoleKey key) =>
        new(keyChar, key, false, false, false);

    public void Render(int y, int width, bool selected)
    {
        if (selected)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        Console.CursorLeft = 1;
        Console.CursorTop = y;

        var k = Key.KeyChar.ToString();

        if (Key.KeyChar == '\u001B')
            k = "Esc";

        var text = $"{k}. {Name}";

        while (text.Length < width - 4)
            text += " ";

        if (text.Length > width - 4)
            text = text.Substring(0, width - 4);

        Console.Write($" {text} ");
    }
}