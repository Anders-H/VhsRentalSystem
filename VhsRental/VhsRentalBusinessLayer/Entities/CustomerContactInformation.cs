namespace VhsRentalBusinessLayer.Entities;

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

    private CustomerContactInformation(VhsRentalDataLayer.Entities.CustomerContactInformation data)
    {
        Id = data.Id;
        Name = data.Name;
        Ssn = data.Ssn;
        Address1 = data.Address1;
        Address2 = data.Address2;
        ZipCode = data.ZipCode;
        City = data.City;
        Phone = data.Phone;
        EMail = data.EMail;
        CustomerNumber = data.CustomerNumber;
        IsBlocked = data.IsBlocked;
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
        try
        {
            var result = VhsRentalDataLayer.Entities.CustomerContactInformation.Get(ssn);

            if (result == null)
                return null;

            return new CustomerContactInformation(result);
        }
        catch
        {
            return null;
        }
    }
}