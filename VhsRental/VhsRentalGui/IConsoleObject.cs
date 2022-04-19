namespace VhsRentalGui;

public interface IConsoleObject
{
    string Ask(string prompt);
    void Clear(ConsoleColor backColor, ConsoleColor foreColor);
    void WriteLine();
    void WriteLine(string output);
    string ReadLine();
}