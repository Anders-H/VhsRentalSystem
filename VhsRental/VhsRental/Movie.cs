namespace VhsRental;

public class Movie
{
    public int MovieId { get; }
    public int CassetteId { get; }
    public string Title { get; }

    public Movie(int movieId, int cassetteId, string title)
    {
        MovieId = movieId;
        CassetteId = cassetteId;
        Title = title;
    }
}