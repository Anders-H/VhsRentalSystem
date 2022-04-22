namespace VhsRentalGui;

public interface IConsoleObject
{
    public ConsoleColor ForeColor { get; set; }
    public ConsoleColor BackColor { get; set; }
    string Ask(string prompt);
    string Ask(string prompt, params char[] acceptOnly);
    string Ask(ConsoleColor foreColor, string prompt);
    string Ask(ConsoleColor foreColor, string prompt, params char[] acceptOnly);
    void Clear(ConsoleColor backColor, ConsoleColor foreColor);
    void WriteLine();
    void WriteLine(string output);
    string ReadLine();
}