using System.Data;
using Microsoft.Data.SqlClient;
using VhsRentalDataLayer.Entities;

namespace VhsRentalDataLayer;

public class RentalService
{
    private readonly int _customerId;
    private readonly int _staffId;
    private readonly DateTime _eventTime;
    private readonly List<PendingRentalDto> _pendingRentals;
    private readonly SqlConnection _connection;
    public int TransactionId { get; private set; }

    public RentalService(int customerId, int staffId, DateTime eventTime)
    {
        _customerId = customerId;
        _staffId = staffId;
        _eventTime = eventTime;
        _pendingRentals = new List<PendingRentalDto>();
        _connection = new SqlConnection(Settings.ConnectionString);
        TransactionId = 0;
    }

    public RentalServiceResult OpenTransaction()
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
                return RentalServiceResult.CustomerNotFound;
            case -3:
                return RentalServiceResult.CustomerBlocked;
        }

        if (id > 0)
        {
            TransactionId = id;
            return RentalServiceResult.Success;
        }

        return RentalServiceResult.UnexpectedResult;
    }

    public RentalServiceResult AddRentalToTransaction(int cassetteId, decimal amount, string description)
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
                return RentalServiceResult.StaffInactiveOrNotFound;
            case -4:
                return RentalServiceResult.CustomerNotFound;
            case -3:
                return RentalServiceResult.CustomerBlocked;
            case -2:
                return RentalServiceResult.CassetteNotFound;
            case -1:
                return RentalServiceResult.CassetteInactive;
            case 0:
                return RentalServiceResult.MovieOrCompanyNotFound;
        }

        return id > 0
            ? RentalServiceResult.Success
            : RentalServiceResult.UnexpectedResult;
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
        using var cn = new SqlConnection(Settings.ConnectionString);
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