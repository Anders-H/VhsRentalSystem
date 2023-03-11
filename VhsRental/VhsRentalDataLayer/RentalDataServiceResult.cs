namespace VhsRentalDataLayer;

public enum RentalDataServiceResult
{
    Success,
    CustomerBlocked,
    CustomerNotFound,
    CassetteInactive,
    CassetteNotFound,
    MovieOrCompanyNotFound,
    StaffInactiveOrNotFound,
    UnexpectedResult
}