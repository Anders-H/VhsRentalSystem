using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class Customer
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
    public int LastCassette { get; set; }
    public decimal CassetteEan { get; set; }
    public int CassetteLastCustomerId { get; set; }
    public string CassetteLastCustomerName { get; set; }
    public int LastMovieId { get; set; }
    public decimal LastMovieEan { get; set; }
    public string LastMovieTitle { get; set; }
    public int TotalNumberOfRentals { get; set; }
    public int CassettesOutNow { get; set; }
    public DateTime? LastActivity { get; set; }

    public Customer(int id, string name, string ssn, string address1, string address2, string zipCode, string city, string phone, string eMail, string customerNumber, bool isBlocked, int lastCassette, decimal cassetteEan, int cassetteLastCustomerId, string cassetteLastCustomerName, int lastMovieId, decimal lastMovieEan, string lastMovieTitle, int totalNumberOfRentals, int cassettesOutNow, DateTime? lastActivity)
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
        LastCassette = lastCassette;
        CassetteEan = cassetteEan;
        CassetteLastCustomerId = cassetteLastCustomerId;
        CassetteLastCustomerName = cassetteLastCustomerName;
        LastMovieId = lastMovieId;
        LastMovieEan = lastMovieEan;
        LastMovieTitle = lastMovieTitle;
        TotalNumberOfRentals = totalNumberOfRentals;
        CassettesOutNow = cassettesOutNow;
        LastActivity = lastActivity;
    }

    public static Customer? Get(int id)
    {
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetCustomer", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);
        var r = cmd.ExecuteReader();
        var result = GetFromReader(r);
        r.Close();
        cn.Close();
        return result;
    }

    public static Customer? Get(string ssn)
    {
        using var cn = new SqlConnection(Settings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.GetCustomerFromSSN", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SSN", ssn);
        var r = cmd.ExecuteReader();
        var result = GetFromReader(r);
        r.Close();
        cn.Close();
        return result;
    }

    private static Customer? GetFromReader(SqlDataReader r)
    {
        var lastCassetteOrdinal = r.GetOrdinal("LastCassette");
        var cassetteEanOrdinal = r.GetOrdinal("CassetteEAN");
        var cassetteLastCustomerIdOrdinal = r.GetOrdinal("CassetteLastCustomerID");
        var cassetteLastCustomerNameOrdinal = r.GetOrdinal("CassetteLastCustomerName");
        var lastMovieIdOrdinal = r.GetOrdinal("LastMovieID");
        var lastMovieEanOrdinal = r.GetOrdinal("LastMovieEAN");
        var lastMovieTitleOrdinal = r.GetOrdinal("LastMovieTitle");
        var lastActivityOrdinal = r.GetOrdinal("LastActivity");

        if (r.Read())
        {
            return new Customer(
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
                r.GetBoolean(r.GetOrdinal("IsBlocked")),
                r.IsDBNull(lastCassetteOrdinal) ? 0 : r.GetInt32(lastCassetteOrdinal),
                r.IsDBNull(cassetteEanOrdinal) ? 0m : r.GetDecimal(cassetteEanOrdinal),
                r.IsDBNull(cassetteLastCustomerIdOrdinal) ? 0 : r.GetInt32(cassetteLastCustomerIdOrdinal),
                r.IsDBNull(cassetteLastCustomerNameOrdinal) ? "" : r.GetString(cassetteLastCustomerNameOrdinal),
                r.IsDBNull(lastMovieIdOrdinal) ? 0 : r.GetInt32(lastMovieIdOrdinal),
                r.IsDBNull(lastMovieEanOrdinal) ? 0m : r.GetDecimal(lastMovieEanOrdinal),
                r.IsDBNull(lastMovieTitleOrdinal) ? "" : r.GetString(lastMovieTitleOrdinal),
                r.GetInt32(r.GetOrdinal("TotalNumberOfRentals")),
                r.GetInt32(r.GetOrdinal("CassettesOut")),
                r.IsDBNull(lastActivityOrdinal) ? null : r.GetDateTime(lastActivityOrdinal)
            );
        }

        return null;
    }
}