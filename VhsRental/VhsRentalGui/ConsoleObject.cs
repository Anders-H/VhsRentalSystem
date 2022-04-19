namespace VhsRentalGui;

public class ConsoleObject : IConsoleObject
{
    public string Ask(string prompt)
    {
        Console.Write(prompt);
        return ReadLine();
    }

    public void Clear(ConsoleColor backColor, ConsoleColor foreColor)
    {
        Console.BackgroundColor = backColor;
        Console.ForegroundColor = foreColor;
        Console.Clear();
    }

    public void WriteLine() =>
        Console.WriteLine();

    public void WriteLine(string output) =>
        Console.WriteLine(output);

    public string ReadLine() =>
        (Console.ReadLine() ?? "").Trim();
}