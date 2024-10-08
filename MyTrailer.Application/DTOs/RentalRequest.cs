namespace MyTrailer.API.DTOs;

public class RentalRequest
{
    public int CustomerId { get; set; }
    public int TrailerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public int Price { get; set; }
}