
using MyTrailer.Domain.Aggregates;

namespace MyTrailer.Infrastructure.Persistence;

public class RentalRepository : IRentalRepository
{
   private readonly MyTrailerDbContext _dbContext;
   
   public RentalRepository(MyTrailerDbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public void Add(Rental rental)
   {
      _dbContext.Rentals.Add(rental);
      _dbContext.SaveChanges();
   }

   public Rental GetById(int id)
   {
     return _dbContext.Rentals.Find(id) ?? throw new InvalidOperationException();
   }

   public IEnumerable<Rental> GetAll()
   {
      return _dbContext.Rentals.ToList();
   }

   public void Update(Rental rental)
   {
      _dbContext.Rentals.Update(rental);
   }

   public void Delete(Rental rental)
   {
      if (rental.Id != null)
      {
         _dbContext.Rentals.Remove(rental);
      }
      throw new InvalidOperationException("Rental not found.");

   }

   public void SaveChanges()
   {
      _dbContext.SaveChanges();
   }
   
   public IEnumerable<Rental> GetRentalsByCustomerId(int customerId)
   {
      return _dbContext.Rentals.Where(r => r.Customer.Id == customerId).ToList();
   }
}
