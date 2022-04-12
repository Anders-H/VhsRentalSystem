using VhsRental;
using VhsRentalBusinessLayer;
using VhsRentalBusinessLayer.Entities;

Console.WriteLine("VHS Rental");
Console.WriteLine();

do
{
    Console.WriteLine("1. Login");
    Console.WriteLine("0. Quit");
    Console.Write("> ");

    var answer = (Console.ReadLine() ?? "").Trim();

    switch (answer)
    {
        case "1":
            if (Login())
                MainMenu();
            break;
        case "0":
            return;
    }

} while (true);

static bool Login()
{
    Console.WriteLine();
    Console.WriteLine("Login.");
    Console.Write("Social security number> ");
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

static void MainMenu()
{
    if (Session.CurrentStaff == null)
        return;

    do
    {
        Console.WriteLine();
        Console.WriteLine($"Main menu for {Session.CurrentStaff.Name}:");
        Console.WriteLine();
        Console.WriteLine("1. Open user interface");
        Console.WriteLine("2. Cassette overview");
        Console.WriteLine("0. Log out");
        Console.Write("> ");

        var answer = (Console.ReadLine() ?? "").Trim();

        switch (answer)
        {
            case "1":
                // TODO
                break;
            case "2":
                CassetteOverview();
                break;
            case "0":
                Session.CurrentStaff = null;
                return;
        }
    } while (true);
}

static void CassetteOverview()
{
    var count = Console.WindowHeight - 3;
    var width = Console.WindowWidth;

    if (count < 5)
        count = 5;

    if (width < 40)
        width = 40;

    var cassetteOverview = new CassetteOverview();

    do
    {
        Console.Write("Movie title> ");
        var title = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(title))
            return;

        var list = cassetteOverview.GetStringList(count, width, title);

        foreach (var item in list)
            Console.WriteLine(item);

    } while (true);
}