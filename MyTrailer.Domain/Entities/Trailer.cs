namespace MyTrailer.Domain.Entities;

public class Trailer
{
    public int Id { get; private set; }
    public string Model { get; private set; }
    public string Location { get; private set; }
    public bool IsBooked { get; internal set; }

    public Trailer(int id, string model, string location)
    {
        Id = id;
        Model = model;
        Location = location;
    }


}