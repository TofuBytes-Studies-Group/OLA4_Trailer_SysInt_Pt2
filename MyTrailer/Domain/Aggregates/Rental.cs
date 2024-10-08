using MyTrailer.Domain.Entities;
using MyTrailer.Domain.ValueObjects;

namespace MyTrailer.Domain.Aggregates;

public class Rental
{
    public int Id { get; private set; }
    public Customer? Customer { get; private set; }
    private Trailer? Trailer { get; set; }
    public Price? Price { get; private set; }
    private DateTime StartDate { get; set; }
    private DateTime EndDate { get; set; }
    public static bool IsInsured { get; set; }

    
    public void RentTrailer(Trailer trailer, Customer customer, DateTime startDate, DateTime endDate)
    {
        if (trailer.IsBooked)
        {
            throw new InvalidOperationException("Trailer is already booked for the selected dates");
        }
        
        StartDate = startDate;
        EndDate = endDate;
        Trailer = trailer;
        Customer = customer;
        trailer.IsBooked = true;
    }

    private bool IsReturnOverdue()
    {
        return DateTime.Now > EndDate && Trailer is { IsBooked: true };
    }
    
    public void CalculatePrice()
    {
        if(IsInsured & IsReturnOverdue())
        {
            Price = new Price(125);
        }
        else if(IsInsured)
        {
            Price = new Price(50);
        }
        else if(IsReturnOverdue())
        {
            Price = new Price(75);
        }
        else
        {
            Price = new Price(0);
        }
    }

}