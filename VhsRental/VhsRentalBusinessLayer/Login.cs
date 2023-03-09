using VhsRentalBusinessLayer.Entities;

namespace VhsRentalBusinessLayer;

public class Login
{
    public Staff? Staff { get; }
    public LoginResult Result { get; }

    internal Login(Staff? staff, LoginResult result)
    {
        Staff = staff;
        Result = result;
    }

    public static Login TryLogin(string ssn)
    {
        try
        {
            var dataStaff = VhsRentalDataLayer.Entities.StaffDto.GetBySsn(ssn);

            if (dataStaff == null)
                return new Login(null, LoginResult.StaffNotFound);

            if (!dataStaff.Active)
                return new Login(null, LoginResult.StaffInactive);

            var staff = new Staff(dataStaff);

            return new Login(staff, LoginResult.Success);
        }
        catch
        {
            return new Login(null, LoginResult.ConnectionError);
        }
    }
}