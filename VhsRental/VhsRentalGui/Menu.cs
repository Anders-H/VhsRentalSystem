namespace VhsRentalGui;

public class Menu
{
    private readonly List<MenuOption> _options;

    public Menu(List<MenuOption> options)
    {
        _options = options;

        Console.CursorSize = 100;

        if (Console.WindowWidth < 80)
            Console.WindowWidth = 80;

        if (Console.WindowHeight < 25)
            Console.WindowHeight = 25;
    }
}