using Microsoft.Data.SqlClient;
using System.Data;

namespace VhsRentalDataLayer.Entities;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Information { get; set; }
    public decimal DefaultCommission { get; set; }

    public CompanyDto(int id, string name, string information, decimal defaultCommission)
    {
        Id = id;
        Name = name;
        Information = information;
        DefaultCommission = defaultCommission;
    }

    public static int Add(string name)
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.RegisterCompany", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", name);
        var id = (int)cmd.ExecuteScalar();
        cn.Close();
        return id;
    }
}