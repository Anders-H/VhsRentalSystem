﻿namespace VhsRentalGui;

public class MenuOption
{
    public ConsoleKeyInfo Key { get; }
    public string Name { get; }

    public MenuOption(ConsoleKeyInfo key, string name)
    {
        Key = key;
        Name = name;
    }

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
        var text = $"{Key.KeyChar}. {Name}";

        if (text.Length > width - 4)
            text = text.Substring(0, width - 4);

        Console.Write($" {text} ");
    }
}