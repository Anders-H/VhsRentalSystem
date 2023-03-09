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

Customer.Add("Dan Dansson", "19810101-1111", "The Street 1", "", "123 45", "The City", "123-123 123", "dan@mail.com");
Customer.Add("Erik Eriksson", "19820101-1111", "The Street 2", "", "123 45", "The City", "123-123 124", "erik@mail.com");
Customer.Add("Fredrik Fredriksson", "19830101-1111", "The Street 3", "", "123 45", "The City", "123-123 125", "fredrik@mail.com");