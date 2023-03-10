namespace VhsRentalBusinessLayer;

public class Administrative
{
    public static bool ClearAllData()
    {
        try
        {
            VhsRentalDataLayer.AdministrativeService.ClearAllData();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool SetSetting(string settingName, string stringValue, decimal moneyValue, int intValue)
    {
        try
        {
            VhsRentalDataLayer.AdministrativeService.SetSetting(settingName, stringValue, moneyValue, intValue);
            return true;
        }
        catch
        {
            return false;
        }
    }
}