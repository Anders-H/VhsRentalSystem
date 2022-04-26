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

        var selectedMovieIds = new List<int>();

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

        var movieMenu = new List<MenuOption<Movie>>();

        var keys = new[]
        {
            MenuOption<Movie>.GetKey('1', ConsoleKey.D1),
            MenuOption<Movie>.GetKey('2', ConsoleKey.D2),
            MenuOption<Movie>.GetKey('3', ConsoleKey.D3),
            MenuOption<Movie>.GetKey('4', ConsoleKey.D4),
            MenuOption<Movie>.GetKey('5', ConsoleKey.D5),
            MenuOption<Movie>.GetKey('6', ConsoleKey.D6),
            MenuOption<Movie>.GetKey('7', ConsoleKey.D7),
            MenuOption<Movie>.GetKey('8', ConsoleKey.D8),
            MenuOption<Movie>.GetKey('9', ConsoleKey.D9),
            MenuOption<Movie>.GetKey('A', ConsoleKey.A)
        };

        if (cassettes.Count > 10)
            throw new SystemException("Expected a maximum of 10 cassettes.");

        for (var i = 0; i < cassettes.Count; i++)
        {
            var key = keys[i];
            var cassette = cassettes[i];

            var entity = new Movie(cassette.MovieID, cassette.Id, cassette.Title);
            movieMenu.Add(new MenuOption<Movie>(key, entity, cassette.ToString()));
        }

        var nullEntity = new Movie(0, 0, "");
        movieMenu.Add(new MenuOption<Movie>(MenuOption<Movie>.GetKey('\u001B', ConsoleKey.Escape), nullEntity, "Cancel"));

        var menu = new Menu("Select cassette", ConsoleEnvironment.WindowWidth, ConsoleEnvironment.WindowHeight, movieMenu);

        var response = menu.Ask();

        if (response.Id == 0)
            return;

        
    }
}