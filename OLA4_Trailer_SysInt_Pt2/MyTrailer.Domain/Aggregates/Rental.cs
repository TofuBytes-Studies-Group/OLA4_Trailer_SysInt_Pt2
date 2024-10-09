using System.Diagnostics;
using MyTrailer.Domain.Entities;
using MyTrailer.Domain.ValueObjects;

namespace MyTrailer.Domain.Aggregates;

public class Rental
{
    public int Id { get; private set; }
    public Customer Customer { get; private set; }
    public Trailer Trailer { get; private init; }
    public Price Price { get; private set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsInsured { get; private set; }

    protected Rental()
    {
    }

    public Rental(Customer customer, Trailer trailer, DateTime startDate, DateTime endDate, bool isInsured)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Trailer = trailer ?? throw new ArgumentNullException(nameof(trailer));
        StartDate = startDate;
        EndDate = endDate;
        IsInsured = isInsured;

        if (StartDate >= EndDate)
        {
            throw new ArgumentException("Start date must be earlier than end date.");
        }

        RentTrailer();
        
    }
    
    public Rental(Customer customer, Trailer trailer, Price price, DateTime startDate, DateTime endDate, bool isInsured)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Trailer = trailer ?? throw new ArgumentNullException(nameof(trailer));
        Price = price;
        StartDate = startDate;
        EndDate = endDate;
        IsInsured = isInsured;
        
        if (StartDate >= EndDate)
        {
            throw new ArgumentException("Start date must be earlier than end date.");
        }

        RentTrailer();
    }

    // Factory method for creating Rental instances
    public static Rental Create(Customer customer, Trailer trailer, DateTime startDate, DateTime endDate, bool isInsured)
    {
        return new Rental(customer, trailer, startDate, endDate, isInsured);
    }

    private void RentTrailer()
    {
        if (Trailer is { IsRented: true })
        {
            throw new InvalidOperationException("Trailer is already booked for the selected dates");
        }

        Trailer.IsRented = true;
    }

    private bool IsReturnOverdue()
    {
        return DateTime.Now > EndDate && Trailer is { IsRented: true };
    }
    
  

   
}