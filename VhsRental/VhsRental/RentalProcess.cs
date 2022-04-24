using VhsRentalBusinessLayer.Entities;
using VhsRentalGui;

namespace VhsRental;

public class RentalProcess
{
    private readonly IConsoleObject _out;

    public RentalProcess(IConsoleObject consoleObject)
    {
        _out = consoleObject;
    }

    public void Run()
    {
        _out.Clear(ConsoleColor.DarkBlue, ConsoleColor.Cyan);
        _out.WriteLine("Create rental for customer");
        _out.WriteLine();

SelectCustomer:
        var custNum = _out.Ask("Customer social security number or customer number> ");

        if (string.IsNullOrWhiteSpace(custNum))
            return;

        var customer = CustomerContactInformation.Get(custNum);

        if (customer == null)
        {
            var handleMissingCustomer = _out.Ask("Customer not found. [R]etry or [C]ancel? ", 'R', 'C');
            switch (handleMissingCustomer.ToLower())
            {
                case "r":
                    goto SelectCustomer;
                default:
                    return;
            }
        }

        new EntityVisualizer(customer)
            .Write();

        if (customer.IsBlocked)
        {
            _out.Ask(ConsoleColor.Red, "Customer is blocked. Press Enter to continue. ");
            return;

        }

        var accept =  _out.Ask("[A]ccept, [R]etry or [C]ancel? ", 'A', 'R', 'C');

        switch (accept)
        {
            case "r":
                goto SelectCustomer;
            case "c":
                return;
        }

SelectMovie:

        var ean = _out.AskDecimal("EAN? ", true);

        if (ean == null)
            return;

        var cassettes = AvailableCassette.GetAvailableCassettesFromMovieEan(ean.Value);

        if (cassettes.Count <= 0)
        {
            _out.WriteLine("Movie not available.");
            goto SelectMovie;
        }

        var movieMenu = new List<MenuOption>();

        var keys = new[]
        {
            new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false),
            new ConsoleKeyInfo('2', ConsoleKey.D2, false, false, false),
            new ConsoleKeyInfo('3', ConsoleKey.D3, false, false, false),
            new ConsoleKeyInfo('4', ConsoleKey.D4, false, false, false),
            new ConsoleKeyInfo('5', ConsoleKey.D5, false, false, false),
            new ConsoleKeyInfo('6', ConsoleKey.D6, false, false, false),
            new ConsoleKeyInfo('7', ConsoleKey.D7, false, false, false),
            new ConsoleKeyInfo('8', ConsoleKey.D8, false, false, false),
            new ConsoleKeyInfo('9', ConsoleKey.D9, false, false, false),
            new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false),
            new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false),
            new ConsoleKeyInfo('C', ConsoleKey.C, false, false, false),
            new ConsoleKeyInfo('D', ConsoleKey.D, false, false, false),
            new ConsoleKeyInfo('E', ConsoleKey.E, false, false, false),
            new ConsoleKeyInfo('F', ConsoleKey.F, false, false, false),
        };

        for (var i = 0; i < cassettes.Count; i++)
        {
            var key = keys[i];
            var cassette = cassettes[i];

            movieMenu.Add(new MenuOption(key, cassette.ToString()));
        }

        var menu = new Menu("Select cassette", ConsoleEnvironment.WindowWidth, ConsoleEnvironment.WindowHeight, movieMenu);

        menu.Ask();
    }
}