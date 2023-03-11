using System.Data;
using Microsoft.Data.SqlClient;
using VhsRentalDataLayer.Entities;

namespace VhsRentalDataLayer;

public class RentalDataService
{
    private readonly int _customerId;
    private readonly int _staffId;
    private readonly DateTime _eventTime;
    private readonly List<PendingRentalDto> _pendingRentals;
    private readonly SqlConnection _connection;
    public int TransactionId { get; private set; }

    public RentalDataService(int customerId, int staffId, DateTime eventTime)
    {
        _customerId = customerId;
        _staffId = staffId;
        _eventTime = eventTime;
        _pendingRentals = new List<PendingRentalDto>();
        _connection = new SqlConnection(DataSettings.ConnectionString);
        TransactionId = 0;
    }

    public RentalDataServiceResult OpenTransaction()
    {
        TransactionId = 0;
        _connection.Open();
        using var cmd = new SqlCommand("dbo.CreateRentalEventTransaction", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CustomerID", _customerId);
        cmd.Parameters.AddWithValue("@StaffID", _staffId);
        cmd.Parameters.AddWithValue("@EventTime", _eventTime);
        var r = cmd.ExecuteReader();
        var id = 0;
        if (r.Read())
            id = r.GetInt32(0);
        r.Close();

        switch (id)
        {
            case -4:
                return RentalDataServiceResult.CustomerNotFound;
            case -3:
                return RentalDataServiceResult.CustomerBlocked;
        }

        if (id > 0)
        {
            TransactionId = id;
            return RentalDataServiceResult.Success;
        }

        return RentalDataServiceResult.UnexpectedResult;
    }

    public RentalDataServiceResult AddRentalToTransaction(int cassetteId, decimal amount, string description)
    {
        _pendingRentals.Add(new PendingRentalDto(cassetteId, amount));
        using var cmd = new SqlCommand("dbo.CreateRental", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TransactionID", TransactionId);
        cmd.Parameters.AddWithValue("@StaffID", _staffId);
        cmd.Parameters.AddWithValue("@CustomerID", _customerId);
        cmd.Parameters.AddWithValue("@CassetteID", cassetteId);
        cmd.Parameters.AddWithValue("@Amount", amount);
        cmd.Parameters.AddWithValue("@EventTime", _eventTime);
        cmd.Parameters.AddWithValue("@Description", description);
        var r = cmd.ExecuteReader();
        var id = 0;
        if (r.Read())
            id = r.GetInt32(0);
        r.Close();

        switch (id)
        {
            case -5:
                return RentalDataServiceResult.StaffInactiveOrNotFound;
            case -4:
                return RentalDataServiceResult.CustomerNotFound;
            case -3:
                return RentalDataServiceResult.CustomerBlocked;
            case -2:
                return RentalDataServiceResult.CassetteNotFound;
            case -1:
                return RentalDataServiceResult.CassetteInactive;
            case 0:
                return RentalDataServiceResult.MovieOrCompanyNotFound;
        }

        return id > 0
            ? RentalDataServiceResult.Success
            : RentalDataServiceResult.UnexpectedResult;
    }

    public void CloseTransaction(bool canceled)
    {
        using var cmd = new SqlCommand("dbo.CloseRentalTransaction", _connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", TransactionId);
        cmd.Parameters.AddWithValue("@Amount", _pendingRentals.Sum(x => x.Amount));
        cmd.Parameters.AddWithValue("@Canceled", canceled);
        cmd.ExecuteNonQuery();
        _connection.Close();
        _connection.Dispose();
    }

    public static void ReturnCassette(int cassetteId, int staffId, string description)
    {
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.ReturnCassette", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", cassetteId);
        cmd.Parameters.AddWithValue("@StaffID", staffId);
        cmd.Parameters.AddWithValue("@Description", description);
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}