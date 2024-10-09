using MyTrailer.Domain.Aggregates;

namespace MyTrailer.Infrastructure;

public interface IRentalRepository
{
    void Add(Rental rental);
    Rental GetById(int id);
    IEnumerable<Rental> GetAll();
    void Update(Rental rental);
    void Delete(Rental rental);
    void SaveChanges();
    IEnumerable<Rental> GetRentalsByCustomerId(int customerId);
}