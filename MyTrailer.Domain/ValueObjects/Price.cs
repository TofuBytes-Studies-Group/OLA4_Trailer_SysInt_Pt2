namespace MyTrailer.Domain.ValueObjects;

public class Price
{
    public decimal Amount { get; }
    public Price(decimal amount)
    {
        Amount = amount;
    }
    
    public override bool Equals(object? obj)
    {
        return obj is Price price && Amount == price.Amount;
    }

    public override int GetHashCode()
    {
        return Amount.GetHashCode();
    }

}