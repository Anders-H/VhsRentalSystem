using VhsRentalDataLayer.Entities;

namespace VhsRentalBusinessLayer.Entities;

public class Movie
{
    public static int RegisterMovie(decimal ean, string title, short year, int companyId, int cassetteCount)
    {
        try
        {
            var id = MovieDto.RegisterMovie(ean, title, year, companyId, cassetteCount);

            return id;
        }
        catch
        {
            return 0;
        }
    }
}