namespace VhsRentalGui;

public class ConsoleObject : IConsoleObject
{
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