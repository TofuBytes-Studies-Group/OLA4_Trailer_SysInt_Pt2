using MyTrailer.Domain.Aggregates;
using MyTrailer.Domain.Entities;
using MyTrailer.Domain.ValueObjects;

namespace RentalTests;

public class RentalTests
{
    // Testene var Kun for at se om jeg havde forstået måden at skrive switch på i CalculatePrice.
    [Fact]
    public void CalculatePrice_ShouldReturn125_WhenInsuredAndReturnOverdue()
    {
        var customer = new Customer();
        var trailer = new Trailer( 1, "Model", "locationlocationlocation", false);
        var rental = new Rental(customer, trailer, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), true);
        
        rental.CalculatePrice();
        Assert.Equal(125, rental.Price.Amount);
    }

    [Fact]
    public void CalculatePrice_ShouldReturn50_WhenInsuredAndReturnNotOverdue()
    {
        var customer = new Customer();
        var trailer = new Trailer(1, "Model", "locationlocation", false);
        var rental = new Rental(customer, trailer, DateTime.Now, DateTime.Now.AddDays(1), true);
        
        rental.CalculatePrice();
        Assert.Equal(50, rental.Price.Amount);
    }

    [Fact]
    public void CalculatePrice_ShouldReturn75_WhenNotInsuredAndReturnOverdue()
    {
        var customer = new Customer();
        var trailer = new Trailer(1, "Model", "Jem&Fix/Farum", false);
        var rental = new Rental(customer, trailer, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), false);

        rental.CalculatePrice();
        Assert.Equal(75, rental.Price.Amount);
    }

    [Fact]
    public void CalculatePrice_ShouldReturn0_WhenNotInsuredAndReturnNotOverdue()
    {
        var customer = new Customer();
        var trailer = new Trailer (1, "Model", "Jem&Fix/Farum", false);
        var rental = new Rental(customer, trailer, DateTime.Now, DateTime.Now.AddDays(1), false);

        rental.CalculatePrice();
        Assert.Equal(0, rental.Price.Amount);
    }
}
