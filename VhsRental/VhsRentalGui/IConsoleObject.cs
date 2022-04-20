namespace VhsRentalGui;

public interface IConsoleObject
{
    string Ask(string prompt);
    string Ask(string prompt, params char[] acceptOnly);
    void Clear(ConsoleColor backColor, ConsoleColor foreColor);
    void WriteLine();
    void WriteLine(string output);
    string ReadLine();
}