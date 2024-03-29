﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace VhsRentalDataLayer.Entities;

public class CustomerSearchResultEntityDto
{
    public int Id { get; }
    public string Name { get; }
    public string Ssn { get; }
    public bool IsBlocked { get; }
    public string LastMovieTitle { get; }
    public int TotalNumberOfRentals { get; }
    public int CassettesOutNow { get; }
    public DateTime? LastActivity { get; }

    public CustomerSearchResultEntityDto(int id, string name, string ssn, bool isBlocked, string lastMovieTitle, int totalNumberOfRentals, int cassettesOutNow, DateTime? lastActivity)
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

    public static List<CustomerSearchResultEntityDto> Search(string s)
    {
        var result = new List<CustomerSearchResultEntityDto>();
        using var cn = new SqlConnection(DataSettings.ConnectionString);
        cn.Open();
        using var cmd = new SqlCommand("dbo.SearchCustomer", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SearchString", s);
        var r = cmd.ExecuteReader();

        var idOrdinal = r.GetOrdinal("ID");
        var nameOrdinal = r.GetOrdinal("Name");
        var ssnOrdinal = r.GetOrdinal("SSN");
        var isBlockedOrdinal = r.GetOrdinal("IsBlocked");
        var lastMovieTitleOrdinal = r.GetOrdinal("LastMovieTitle");
        var totalNumberOfRentalsOrdinal = r.GetOrdinal("TotalNumberOfRentals");
        var cassettesOutNowOrdinal = r.GetOrdinal("CassettesOutNow");
        var lastActivityOrdinal = r.GetOrdinal("LastActivity");

        while (r.Read())
            result.Add(
                new CustomerSearchResultEntityDto(
                    r.GetInt32(idOrdinal),
                    r.GetString(nameOrdinal),
                    r.GetString(ssnOrdinal),
                    r.GetBoolean(isBlockedOrdinal),
                    r.IsDBNull(lastMovieTitleOrdinal) ? "" : r.GetString(lastMovieTitleOrdinal),
                    r.IsDBNull(totalNumberOfRentalsOrdinal) ? 0 : r.GetInt32(totalNumberOfRentalsOrdinal),
                    r.IsDBNull(cassettesOutNowOrdinal) ? 0 : r.GetInt32(cassettesOutNowOrdinal),
                    r.IsDBNull(lastActivityOrdinal) ? null : r.GetDateTime(lastActivityOrdinal)
                )
            );

        r.Close();
        cn.Close();
        return result;
    }
}