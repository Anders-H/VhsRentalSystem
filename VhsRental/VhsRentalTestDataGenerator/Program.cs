using VhsRentalBusinessLayer;
using VhsRentalBusinessLayer.Entities;

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

Staff.RegisterStaff("Anders Andersson", "19610101-1111");
Staff.RegisterStaff("Bengt Bengtsson", "19620101-1111");
Staff.RegisterStaff("Carl Carlsson", "19630101-1111");
