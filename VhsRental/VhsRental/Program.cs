using VhsRental;
using VhsRentalGui;

Console.Title = "VHS Rental";

var o = new ConsoleObject();

ConsoleEnvironment.FixConsoleWindowSize();

Start:

var mainMenu = new Menu("VHS Rental", ConsoleEnvironment.WindowWidth, ConsoleEnvironment.WindowHeight, new List<MenuOption>
{
    new(new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false), "Login"),
    new(new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false), "Quit")
});

Console.WriteLine();
Console.WriteLine();

var answer = mainMenu.Ask();

switch (answer.Key.KeyChar)
{
    case '1':
        if (new LoginProcess(o).Run())
            MainMenu(o);
        else
            goto Start;
        break;
    case '0':
        return;
}

static void MainMenu(IConsoleObject o)
{
    do
    {

        if (Session.CurrentStaff == null)
            return;

        var mainMenuFor = new Menu($"VHS Rental - main menu for {Session.CurrentStaff.Name}", ConsoleEnvironment.WindowWidth, ConsoleEnvironment.WindowHeight, new List<MenuOption>
        {
            new(new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false), "Create rental for customer"),
            new(new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false), "Quit")
        });

        var answer = mainMenuFor.Ask();

        switch (answer.Key.KeyChar)
        {
            case '1':
                var x = new RentalProcess(o);
                x.Run();
                break;
            case '0':
                Session.CurrentStaff = null;
                return;
        }
    } while (true);
}