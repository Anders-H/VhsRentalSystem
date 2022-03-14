using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class Staff
{
    public int Id { get; }
    public string Name { get; }
    public string Ssn { get; }
    public bool Active { get; }

    public Staff(int id, string name, string ssn, bool active)
    {
        Id = id;
        Name = name;
        Ssn = ssn;
        Active = active;
    }

    public static Staff? GetBySsn(string ssn)
    {
        Staff? result = null;
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetStaffFromSSN", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SSN", ssn);
        var r = cmd.ExecuteReader();
        
        if (r.Read())
            result = new Staff(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetBoolean(3));

        r.Close();
        cn.Close();
        return result;
    }
}