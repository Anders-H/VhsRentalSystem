using VhsRental;
using VhsRentalBusinessLayer;

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

    Console.WriteLine($"Welcome {Session.CurrentStaff.Name}!");

    do
    {
        Console.WriteLine("0. Log out");
        Console.Write("> ");

        var answer = (Console.ReadLine() ?? "").Trim();

        switch (answer)
        {
            case "0":
                Session.CurrentStaff = null;
                return;
        }
    } while (true);
}