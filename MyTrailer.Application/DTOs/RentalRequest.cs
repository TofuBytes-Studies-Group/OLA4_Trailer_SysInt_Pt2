using System.ComponentModel.DataAnnotations;

namespace MyTrailer.Application.DTOs;

public class RentalRequest
{
    public int CustomerId { get; set; }
    
    public int TrailerId { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    
    public bool IsInsured { get; set; }
}