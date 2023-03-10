using System.Configuration;

namespace VhsRentalDataLayer;

public static class DataSettings
{
    public static string ConnectionString =>
        ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
}