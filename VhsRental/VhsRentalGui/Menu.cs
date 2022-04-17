using System.Reflection;

namespace VhsRentalGui;

public class Menu : GuiObject
{
    private readonly List<MenuOption> _options;
    private readonly string _title;
    private int _width;


    public Menu(string title, List<MenuOption> options)
    {
        _options = options;
        _title = title;

        _width = Console.WindowWidth;

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.WriteLine(Pad(_title));
        Console.BackgroundColor = ConsoleColor.Black;
        _options = options;

        Console.CursorTop = 2;
        Console.WriteLine($" Application version: {Assembly.GetExecutingAssembly().GetName().Version}");
    }

    private string Pad(string text)
    {
        var s = new string(' ', _width);
        var result = $"{text}{s}";
        return result.Substring(0, _width);
    }

    public MenuOption Ask()
    {
        var yStart = 4;
        var selectedIndex = 0;

        do
        {
            var y = yStart;
            var renderIndex = 0;

            foreach (var option in _options)
            {
                option.Render(y, _width, selectedIndex == renderIndex);
                y++;
                renderIndex++;
            }

            Console.CursorLeft = 0;
            Console.CursorTop = ++y;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("> ");

            var key = Console.ReadKey();
            var keyChar = key.KeyChar;

            foreach (var menuOption in _options)
            {
                if (menuOption.Key.KeyChar == keyChar)
                    return menuOption;
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= _options.Count)
                    selectedIndex = 0;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = _options.Count - 1;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Write($"> {_options[selectedIndex].Key.KeyChar}");
                return _options[selectedIndex];
            }

        } while (true);
    }
}