namespace MyTrailer.Domain.ValueObjects;

public class Price
{
    public int Amount { get; private set; }
    public Price(int amount)
    {
        Amount = amount;
    }

}