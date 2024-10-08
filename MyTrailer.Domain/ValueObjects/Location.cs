namespace MyTrailer.Domain.ValueObjects;

public class Location
{
    public string City { get; private set; }
    
    public Location(string city)
    {
        City = city;
    }
}