using VhsRentalBusinessLayer.Entities;

namespace VhsRental;

public class RentalProcess
{
    public void Run()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Console.WriteLine("Create rental for customer");
        Console.WriteLine();

SelectCustomer:
        Console.Write("Customer social security number or customer number> ");
        var custNum = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(custNum))
            return;

        var customer = CustomerContactInformation.Get(custNum);

        if (customer == null)
        {
            Console.Write("Customer not found. [R]etry or [C]ancel? ");
            var handleMissingCustomer = (Console.ReadLine() ?? "");
            switch (handleMissingCustomer.ToLower())
            {
                case "r":
                    goto SelectCustomer;
                default:
                    return;
            }
        }
    }
}