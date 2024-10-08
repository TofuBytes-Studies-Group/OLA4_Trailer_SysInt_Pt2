namespace MyTrailer.Domain.ValueObjects;

public class Location
{
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    
    public Location(string city, string zipCode)
    {
        City = city;
        ZipCode = zipCode;
    }
}