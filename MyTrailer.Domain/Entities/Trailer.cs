namespace MyTrailer.Domain.Entities;

public class Trailer
{
    public int Id { get; private set; }
    public string Model { get; private set; }
    public string Location { get; private set; }
    public bool IsBooked { get; set; }

    public Trailer(int id, string model, string location)
    {
        Id = id;
        Model = model;
        Location = location;
    }
    
    public Trailer(int id, string model, string location, bool isBooked) // for testing of calculatePrice
    {
        Id = id;
        Model = model;
        Location = location;
        IsBooked = isBooked;
    }
    
}