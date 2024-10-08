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
        CalculatePrice();
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

    public void CalculatePrice()
    {
        decimal amount = IsInsured switch //amount er sat til samme værdi som IsInsured switch / boolean
        {
            true when IsReturnOverdue() => 125, // Hvis IsInsured er true og IsReturnOverdue er true, så er amount 125
            true => 50, // Hvis IsInsured er true, så er amount 50
            _ => IsReturnOverdue()
                ? 75
                : 0 // Hvis ingen af dem er true, så er amount 75 HVIS IsReturnOverdue er true, ellers er amount 0
        };
        Price = new Price(amount); // Price er sat til amount
    }
}