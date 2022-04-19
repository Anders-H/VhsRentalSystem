using VhsRental;
using VhsRentalBusinessLayer;
using VhsRentalGui;

var o = new ConsoleObject();

var mainMenu = new Menu("VHS Rental", new List<MenuOption>
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
        if (Login())
            MainMenu(o);
        break;
    case '0':
        return;
}

static bool Login()
{
    Console.WriteLine();
    Console.WriteLine("Login.");
    Console.Write("Your social security number> ");
    var ssn = (Console.ReadLine() ?? "").Trim();

    if (string.IsNullOrWhiteSpace(ssn))
        return false;

    var result = VhsRentalBusinessLayer.Login.TryLogin(ssn);

    switch (result.Result)
    {
        case LoginResult.Success:
            Session.CurrentStaff = result.Staff;
            return true;
        case LoginResult.StaffInactive:
            Console.WriteLine("Inactive staff.");
            return false;
        case LoginResult.StaffNotFound:
            Console.WriteLine("Not found.");
            return false;
        case LoginResult.ConnectionError:
            Console.WriteLine("Database connection error");
            return false;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

static void MainMenu(IConsoleObject o)
{
    do
    {

        if (Session.CurrentStaff == null)
            return;

        var mainMenuFor = new Menu($"VHS Rental - main menu for {Session.CurrentStaff.Name}", new List<MenuOption>
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