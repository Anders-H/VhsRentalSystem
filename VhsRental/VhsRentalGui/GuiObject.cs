namespace VhsRentalGui;

public abstract class GuiObject
{
    protected GuiObject()
    {
        Console.CursorSize = 100;

        if (Console.WindowWidth < 80)
            Console.WindowWidth = 80;

        if (Console.WindowHeight < 25)
            Console.WindowHeight = 25;
    }
}