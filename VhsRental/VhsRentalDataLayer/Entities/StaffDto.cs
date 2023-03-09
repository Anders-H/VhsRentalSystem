using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class StaffDto
{
    public int Id { get; }
    public string Name { get; }
    public string Ssn { get; }
    public bool Active { get; }

    public StaffDto(int id, string name, string ssn, bool active)
    {
        Id = id;
        Name = name;
        Ssn = ssn;
        Active = active;
    }

    public static int RegisterStaff(string name, string ssn)
    {
        if (name.Length > 50)
            name = name.Substring(0, 50).Trim();

        if (ssn.Length > 50)
            ssn = ssn.Substring(0, 50).Trim();

        var id = 0;

        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.RegisterStaff", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@SSN", ssn);
        var r = cmd.ExecuteReader();
        if (r.Read())
            id = r.IsDBNull(0) ? 0 : r.GetInt32(0);
        r.Close();
        cn.Close();
        return id;
    }

    public static StaffDto? GetBySsn(string ssn)
    {
        StaffDto? result = null;
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetStaffFromSSN", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SSN", ssn);
        var r = cmd.ExecuteReader();
        
        if (r.Read())
            result = new StaffDto(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetBoolean(3));

        r.Close();
        cn.Close();
        return result;
    }

    public static StaffDto? GetById(int id)
    {
        StaffDto? result = null;
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetStaffFromID", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);
        var r = cmd.ExecuteReader();

        if (r.Read())
            result = new StaffDto(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetBoolean(3));

        r.Close();
        cn.Close();
        return result;
    }
}