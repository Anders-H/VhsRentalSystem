using VhsRentalBusinessLayer;
using VhsRentalGui;

namespace VhsRental;

public class LoginProcess
{
    private readonly IConsoleObject _out;

    public LoginProcess(IConsoleObject consoleObject)
    {
        _out = consoleObject;
    }

    public bool Run()
    {
        _out.WriteLine();
        _out.WriteLine("Login.");
        _out.WriteLine();
        do
        {
            var ssn = _out.Ask("Your social security number> ");

            if (string.IsNullOrWhiteSpace(ssn))
                return false;

            var result = Login.TryLogin(ssn);

            switch (result.Result)
            {
                case LoginResult.Success:
                    Session.CurrentStaff = result.Staff;
                    return true;
                case LoginResult.StaffInactive:
                    _out.WriteLine("Inactive staff.");
                    break;
                case LoginResult.StaffNotFound:
                    _out.WriteLine("Not found.");
                    break;
                case LoginResult.ConnectionError:
                    _out.WriteLine("Database connection error");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } while (true);
    }
}