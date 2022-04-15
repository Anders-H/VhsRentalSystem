namespace VhsRentalDataLayer;

public enum RentalServiceResult
{
    Success,
    CustomerBlocked,
    CustomerNotFound,
    CassetteInactive,
    CassetteNotFound,
    MovieOrCompanyNotFound,
    StaffInactiveOrNotFound,
    ConnectionError
}