using VhsRentalBusinessLayer;

Console.WriteLine("VHS Rental test data generator");
Console.WriteLine("==============================");
Console.WriteLine();
Console.WriteLine("All data will be erased.");
Console.Write("Are you sure? ");
var answer = Console.ReadLine() ?? "";

if (!answer.ToLower().StartsWith("y"))
    return;

if (!Administrative.ClearAllData())
{
    Console.WriteLine("Failed to clear all data.");
    return;
}

Administrative.SetSetting("DefaultCustomerPrice", "", 25, 0);
Administrative.SetSetting("DefaultCompanyCommission", "", 6, 0);
