using Microsoft.Data.SqlClient;
using VhsRentalDataLayer.Entities;

namespace VhsRentalDataLayer;

public class RentalService
{
    private readonly int _customerId;
    private readonly int _staffId;
    private readonly DateTime _eventTime;
    private readonly List<PendingRental> _pendingRentals;
    private SqlConnection _connection;
    public int TransactionId { get; private set; }

    public RentalService(int customerId, int staffId, DateTime eventTime)
    {
        _customerId = customerId;
        _staffId = staffId;
        _eventTime = eventTime;
        _pendingRentals = new List<PendingRental>();
        TransactionId = 0;
    }

    public bool OpenTransaction()
    {
        _connection = new SqlConnection(Settings.ConnectionString);
        _connection.Open();
    }

    public RentalServiceResult AddRentalToTransaction(int cassetteId, decimal amount)
    {
        _pendingRentals.Add(new PendingRental(cassetteId, amount));

    }

    public RentalServiceResult CloseTransaction()
    {


        _connection.Close();
        _connection.Dispose();
    }
}