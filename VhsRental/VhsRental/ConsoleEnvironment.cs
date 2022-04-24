using System.Runtime.InteropServices;

namespace VhsRental;

public class ConsoleEnvironment
{
    private const int MfBycommand = 0x00000000;
    private const int ScMinimize = 0xF020;
    private const int ScMaximize = 0xF030;
    private const int ScSize = 0xF000;

    public const int WindowWidth = 80;
    public const int WindowHeight = 50;

    [DllImport("user32.dll")]
    public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();

    public static void FixConsoleWindowSize()
    {
        Console.WindowWidth = WindowWidth;
        Console.WindowHeight = WindowHeight;
        Console.BufferWidth = WindowWidth;
        Console.BufferHeight = WindowHeight;
        Console.WindowLeft = 0;
        Console.WindowTop = 0;

        _ = DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScMinimize, MfBycommand);
        _ = DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScMaximize, MfBycommand);
        _ = DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), ScSize, MfBycommand);
    }
}