using VhsRentalBusinessLayer.Entities;

namespace VhsRental;

public static class Context
{
    public static string ConnectionString =>
        System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

    public static Staff? CurrentStaff { get; set; }
}