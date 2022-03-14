namespace VhsRentalBusinessLayer.Entities;

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

    internal Staff(VhsRentalDataLayer.Entities.Staff staff) : this(staff.Id, staff.Name, staff.Ssn, staff.Active)
    {
    }
}