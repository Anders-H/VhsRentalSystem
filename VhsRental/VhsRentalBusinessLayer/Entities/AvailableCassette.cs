using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VhsRentalBusinessLayer.Entities;

public class AvailableCassette
{
    private string StringRepresentation { get; set; }

    public int Id { get; set; }
    public string Title { get; set; }
    public short Year { get; set; }
    public decimal CustomerPrice { get; set; }
    public int NumberOfCopies { get; set; }

    public AvailableCassette() : this(0, "", 0, 0, 0)
    {
    }

    public AvailableCassette(int id, string title, short year, decimal customerPrice, int numberOfCopies)
    {
        StringRepresentation = "";

        Id = id;
        Title = title;
        Year = year;
        CustomerPrice = customerPrice;
        NumberOfCopies = numberOfCopies;
    }

    private AvailableCassette(VhsRentalDataLayer.Entities.AvailableCassette data)
    {
        Id = data.Id;
        Title = data.Title;
        Year = data.Year;
        CustomerPrice = data.CustomerPrice;
        NumberOfCopies = data.NumberOfCopies;
    }

    public static List<AvailableCassette> GetAvailableCassettesFromMovieEan(decimal ean)
    {
        var result = new List<AvailableCassette>();

        try
        {
            var sourceList = VhsRentalDataLayer.Entities.AvailableCassette.GetAvailableCassettesFromMovieEan(ean);
            result.AddRange(sourceList.Select(s => new AvailableCassette(s)));
        }
        catch
        {
            // ignored
        }

        return result;
    }

    public string GetStringRepresentation(int width)
    {
        if (StringRepresentation.Length != width)
            GenerateStringRepresentation(width);

        return StringRepresentation;
    }

    private void GenerateStringRepresentation(int width)
    {

    }
}