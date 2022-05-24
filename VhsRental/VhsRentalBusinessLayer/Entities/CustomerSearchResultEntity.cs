namespace VhsRentalBusinessLayer.Entities;

public class CustomerSearchResultEntity
{
    public int Id { get; }
    public string Name { get; }
    public string Ssn { get; }
    public bool IsBlocked { get; }
    public string LastMovieTitle { get; }
    public int TotalNumberOfRentals { get; }
    public int CassettesOutNow { get; }
    public DateTime? LastActivity { get; }

    public CustomerSearchResultEntity(int id, string name, string ssn, bool isBlocked, string lastMovieTitle, int totalNumberOfRentals, int cassettesOutNow, DateTime? lastActivity)
    {
        Id = id;
        Name = name;
        Ssn = ssn;
        IsBlocked = isBlocked;
        LastMovieTitle = lastMovieTitle;
        TotalNumberOfRentals = totalNumberOfRentals;
        CassettesOutNow = cassettesOutNow;
        LastActivity = lastActivity;
    }

    internal CustomerSearchResultEntity(VhsRentalDataLayer.Entities.CustomerSearchResultEntity customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Ssn = customer.Ssn;
        IsBlocked = customer.IsBlocked;
        LastMovieTitle = customer.LastMovieTitle;
        TotalNumberOfRentals = customer.TotalNumberOfRentals;
        CassettesOutNow = customer.CassettesOutNow;
        LastActivity = customer.LastActivity;
    }

    public static List<CustomerSearchResultEntity> Search(string s)
    {
        try
        {
            var hits = VhsRentalDataLayer.Entities.CustomerSearchResultEntity.Search(s);

            return hits
                .Select(customerSearchResultEntity => new CustomerSearchResultEntity(customerSearchResultEntity))
                .ToList();
        }
        catch
        {
            return new List<CustomerSearchResultEntity>();
        }
    }
}