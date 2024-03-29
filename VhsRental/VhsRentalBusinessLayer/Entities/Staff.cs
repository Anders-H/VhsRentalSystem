﻿namespace VhsRentalBusinessLayer.Entities;

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

    internal Staff(VhsRentalDataLayer.Entities.StaffDto staff) : this(staff.Id, staff.Name, staff.Ssn, staff.Active)
    {
    }

    public override string ToString() =>
        string.IsNullOrWhiteSpace(Name) ? $"Employee {Id}" : Name.Trim();

    public static Staff? RegisterStaff(string name, string ssn)
    {
        var id = VhsRentalDataLayer.Entities.StaffDto.RegisterStaff(name, ssn);

        if (id <= 0)
            return null;

        var staff = VhsRentalDataLayer.Entities.StaffDto.GetById(id);

        return staff == null ? null : new Staff(staff);
    }
}