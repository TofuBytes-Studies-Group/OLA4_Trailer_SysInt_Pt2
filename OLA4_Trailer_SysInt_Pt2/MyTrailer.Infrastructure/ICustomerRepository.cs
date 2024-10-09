using MyTrailer.Domain.Entities; 

namespace MyTrailer.Infrastructure;

public interface ICustomerRepository
{
    void Add(Customer customer); 
    Customer GetById(int id);
    IEnumerable<Customer> GetAll();
    void Update(Customer customer); 
    void Delete(int id); 
    void SaveChanges(); 
}