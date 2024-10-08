using MyTrailer.Domain.Entities;
namespace MyTrailer.Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
    private readonly MyTrailerDbContext _context;

    public CustomerRepository(MyTrailerDbContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public Customer GetById(int id)
    {
        return _context.Customers.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void Delete(int id)
    {
        var customer = GetById(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}