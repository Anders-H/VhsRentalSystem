namespace VhsRentalBusinessLayer.Entities;

public class CustomerContactInformation
{
    public int Id { get; set; }

    [PropertyVisualizer(0, "Name")]
    public string Name { get; set; }
    
    [PropertyVisualizer(0, "Social security number")]
    public string Ssn { get; set; }
    
    [PropertyVisualizer(0, "Address 1")]
    public string Address1 { get; set; }
    
    [PropertyVisualizer(0, "Address 2")]
    public string Address2 { get; set; }
    
    [PropertyVisualizer(0, "Zip")]
    public string ZipCode { get; set; }
    
    [PropertyVisualizer(0, "City")]
    public string City { get; set; }
    
    [PropertyVisualizer(0, "Phone")]
    public string Phone { get; set; }
    
    [PropertyVisualizer(0, "E-mail")]
    public string EMail { get; set; }
    
    [PropertyVisualizer(0, "Customer number")]
    public string CustomerNumber { get; set; }
    
    [PropertyVisualizer(0, "Blocked")]
    public bool IsBlocked { get; set; }

    public CustomerContactInformation() : this(0, "", "", "", "", "", "", "", "", "", false)
    {
    }

    private CustomerContactInformation(VhsRentalDataLayer.Entities.CustomerContactInformationDto data)
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
            var result = VhsRentalDataLayer.Entities.CustomerContactInformationDto.Get(ssn);

            if (result == null)
                return null;

            return new CustomerContactInformation(result);
        }
        catch
        {
            return null;
        }
    }

    public static CustomerContactInformation? Get(int id)
    {
        try
        {
            var result = VhsRentalDataLayer.Entities.CustomerContactInformationDto.Get(id);

            if (result == null)
                return null;

            return new CustomerContactInformation(result);
        }
        catch
        {
            return null;
        }
    }

    public override string ToString() =>
        $"{(string.IsNullOrWhiteSpace(Name) ? Id : Name)}{(IsBlocked ? " (BLOCKED)" : "")}";
}