using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer;

public class AdministrativeService
{
    public static void ClearAllData()
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();

        using var cmd = new SqlCommand(@"
DELETE FROM dbo.Cassette
DELETE FROM dbo.Company
DELETE FROM dbo.Customer
DELETE FROM dbo.[Event]
DELETE FROM dbo.Movie
DELETE FROM dbo.RentalEvent
DELETE FROM dbo.RentalEventTransaction
DELETE FROM dbo.Setting
DELETE FROM dbo.Staff
", cn);

        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public static void SetSetting(string settingName, string stringValue, decimal moneyValue, int intValue)
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();

        using var cmd = new SqlCommand("dbo.SetSetting", cn);
        cmd.Parameters.AddWithValue("@SettingName", settingName);
        cmd.Parameters.AddWithValue("@StringValue", stringValue);
        cmd.Parameters.AddWithValue("@MoneyValue", moneyValue);
        cmd.Parameters.AddWithValue("@IntValue", intValue);

        cmd.ExecuteNonQuery();
        cn.Close();
    }
}