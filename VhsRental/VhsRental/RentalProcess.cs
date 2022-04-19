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
            var handleMissingCustomer = _out.Ask("Customer not found. [R]etry or [C]ancel? ");
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

        _out.WriteLine("[A]ccept, [R]etry or [C]ancel? ");


        _out.ReadLine();
    }
}