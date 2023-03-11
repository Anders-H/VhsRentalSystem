using VhsRentalDataLayer.Entities;

namespace VhsRentalBusinessLayer.Entities;

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

    public Customer() : this(0, "", "", "", "", "", "", "", "", "", false, 0, 0m, 0, "", 0, 0m, "", 0, 0, null)
    {
    }

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

    private Customer(CustomerDto customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Ssn = customer.Ssn;
        Address1 = customer.Address1;
        Address2 = customer.Address2;
        ZipCode = customer.ZipCode;
        City = customer.City;
        Phone = customer.Phone;
        EMail = customer.EMail;
        CustomerNumber = customer.CustomerNumber;
        IsBlocked = customer.IsBlocked;
        LastCassette = customer.LastCassette;
        CassetteEan = customer.CassetteEan;
        CassetteLastCustomerId = customer.CassetteLastCustomerId;
        CassetteLastCustomerName = customer.CassetteLastCustomerName;
        LastMovieId = customer.LastMovieId;
        LastMovieEan = customer.LastMovieEan;
        LastMovieTitle = customer.LastMovieTitle;
        TotalNumberOfRentals = customer.TotalNumberOfRentals;
        CassettesOutNow = customer.CassettesOutNow;
        LastActivity = customer.LastActivity;
    }

    public static Customer? Get(int id)
    {
        try
        {
            var result = CustomerDto.Get(id);

            if (result == null)
                return null;

            return new Customer(result);
        }
        catch
        {
            return null;
        }
    }

    public static Customer? Get(string ssn)
    {
        try
        {
            var result = CustomerDto.Get(ssn);

            if (result == null)
                return null;

            return new Customer(result);
        }
        catch
        {
            return null;
        }
    }

    public static bool Set(Customer customer)
    {
        try
        {
            CustomerDto.Set(
                customer.Id,
                customer.Name,
                customer.Address1,
                customer.Address2,
                customer.ZipCode,
                customer.City,
                customer.Phone,
                customer.EMail,
                customer.IsBlocked
            );

            return true;
        }
        catch
        {
            return false;
        }
    }

    public static int Add(string name, string ssn, string address1, string address2, string zipCode, string city, string phone, string eMail)
    {
        try
        {
            var id = CustomerDto.Add(name, ssn, address1, address2, zipCode, city, phone, eMail);
            
            return id;
        }
        catch
        {
            return 0;
        }
    }
}