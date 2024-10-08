using MyTrailer.Domain.ValueObjects;

namespace MyTrailer.Domain.Entities;

public class Trailer
{
    public int Id { get; private set; }
    public string Model { get; private set; }
    public string Location { get; set; }
    public bool IsRented { get; set; }

    public Trailer(int id, string model, string location)
    {
        Id = id;
        Model = model;
        Location = location;
    }
    
    public Trailer(int id, string model, string location, bool isRented) // for testing of calculatePrice
    {
        Id = id;
        Model = model;
        Location = location;
        IsRented = isRented;
    }
    
}