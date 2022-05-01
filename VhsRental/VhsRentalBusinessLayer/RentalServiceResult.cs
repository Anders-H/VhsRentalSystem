namespace VhsRentalBusinessLayer;

public enum RentalServiceResult
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