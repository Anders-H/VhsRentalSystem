using VhsRentalDataLayer.Entities;

namespace VhsRentalBusinessLayer.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Information { get; set; }
    public decimal DefaultCommission { get; set; }

    public Company(int id, string name, string information, decimal defaultCommission)
    {
        Id = id;
        Name = name;
        Information = information;
        DefaultCommission = defaultCommission;
    }

    private Company(CompanyDto company)
    {
        Id = company.Id;
        Name = company.Name;
        Information = company.Information;
        DefaultCommission = company.DefaultCommission;
    }

    public static int Add(string name)
    {
        try
        {
            var id = CompanyDto.Add(name);

            return id;
        }
        catch
        {
            return 0;
        }
    }
}