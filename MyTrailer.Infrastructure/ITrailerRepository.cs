using MyTrailer.Domain.Entities;

namespace MyTrailer.Infrastructure;

public interface ITrailerRepository
{
    void Add(Trailer trailer);
    Trailer GetById(int id);
    IEnumerable<Trailer> GetAll();
    void Update(Trailer trailer);
    void Delete(int id);
    void SaveChanges();
}