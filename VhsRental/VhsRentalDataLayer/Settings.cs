using System.Configuration;

namespace VhsRentalDataLayer;

public static class Settings
{
    public static string ConnectionString =>
        ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
}