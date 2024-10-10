namespace MyTrailer.Application.DTOs;

public class RentalResponse
{
    public int Id { get; set; } 
    public int CustomerId { get; set; } 
    public int TrailerId { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public decimal TotalPrice { get; set; } 
    public bool IsInsured { get; set; } 
    
    public RentalResponse(int id, int customerId, int trailerId, DateTime startDate, DateTime endDate, decimal totalPrice, bool isInsured)
    {
        Id = id;
        CustomerId = customerId;
        TrailerId = trailerId;
        StartDate = startDate;
        EndDate = endDate;
        TotalPrice = totalPrice;
        IsInsured = isInsured;
    }
}