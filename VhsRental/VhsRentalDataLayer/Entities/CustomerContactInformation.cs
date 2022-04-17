using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class CustomerContactInformation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ssn { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }
    public string CustomerNumber { get; set; }
    public bool IsBlocked { get; set; }

    public CustomerContactInformation() : this(0, "", "", "", "", "", "", "", "", "", false)
    {
    }

    public CustomerContactInformation(int id, string name, string ssn, string address1, string address2, string zipCode, string city, string phone, string eMail, string customerNumber, bool isBlocked)
    {
        Id = id;
        Name = name;
        Ssn = ssn;
        Address1 = address1;
        Address2 = address2;
        ZipCode = zipCode;
        City = city;
        Phone = phone;
        EMail = eMail;
        CustomerNumber = customerNumber;
        IsBlocked = isBlocked;
    }

    public static CustomerContactInformation? Get(string ssn)
    {
        CustomerContactInformation? result = null;
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetCustomerContactInformation", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SSN", ssn);
        var r = cmd.ExecuteReader();
        if (r.Read())
        {
            result = new CustomerContactInformation(
                r.GetInt32(r.GetOrdinal("ID")),
                r.GetString(r.GetOrdinal("Name")),
                r.GetString(r.GetOrdinal("SSN")),
                r.GetString(r.GetOrdinal("Address1")),
                r.GetString(r.GetOrdinal("Address2")),
                r.GetString(r.GetOrdinal("ZipCode")),
                r.GetString(r.GetOrdinal("City")),
                r.GetString(r.GetOrdinal("Phone")),
                r.GetString(r.GetOrdinal("EMail")),
                r.GetString(r.GetOrdinal("CustomerNumber")),
                r.GetBoolean(r.GetOrdinal("IsBlocked"))
            );
        }
        r.Close();
        cn.Close();
        return result;
    }
}