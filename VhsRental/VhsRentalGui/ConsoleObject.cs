using System.Globalization;

namespace VhsRentalGui;

public class ConsoleObject : IConsoleObject
{
    public ConsoleColor ForeColor { get; set; }
    public ConsoleColor BackColor { get; set; }

    public string Ask(string prompt)
    {
        Console.Write(prompt);
        return ReadLine();
    }

    public string Ask(string prompt, params char[] acceptOnly)
    {
        Console.Write(prompt);

        var accepted = acceptOnly
            .Select(c => c.ToString()
            .ToLower())
            .ToList();

        var message = $"{string.Join(", ", accepted).ToUpper()}? ";
        var messageToShow = false;
        do
        {
            messageToShow = !messageToShow;

            var response = ReadLine().ToLower();

            if (!string.IsNullOrWhiteSpace(response))
            {

                if (response.Length > 1)
                    response = response[..1];

                if (accepted.Any(x => x == response))
                    return response;
            }

            Console.Write(messageToShow ? message : prompt);

        } while (true);
    }

    public string Ask(ConsoleColor foreColor, string prompt)
    {
        Console.ForegroundColor = foreColor;
        return Ask(prompt);
    }

    public string Ask(ConsoleColor foreColor, string prompt, params char[] acceptOnly)
    {
        Console.ForegroundColor = foreColor;
        return Ask(prompt, acceptOnly);
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

    public decimal AskDecimal(string prompt) =>
        AskDecimal(prompt, false)!.Value;

    public decimal? AskDecimal(string prompt, bool canExitOnEnter)
    {
        var s = Ask(prompt);

        do
        {
            if (canExitOnEnter && string.IsNullOrWhiteSpace(s))
                return null;

            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out var d))
                return d;

            s = Ask(canExitOnEnter ? "Enter a numeric value or press Enter to cancel: " : "Enter a numeric value: ");
        } while (true);
    }
}