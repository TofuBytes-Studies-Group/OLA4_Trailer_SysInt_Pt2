using MyTrailer.Domain.Entities; 

namespace MyTrailer.Infrastructure.Persistence;

public class TrailerRepository : ITrailerRepository
{
    private readonly MyTrailerDbContext _context;

    public TrailerRepository(MyTrailerDbContext context)
    {
        _context = context;
    }

    public void Add(Trailer trailer)
    {
        _context.Trailers.Add(trailer);
    }

    public Trailer GetById(int id)
    {
        return _context.Trailers.Find(id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Trailer> GetAll()
    {
        return _context.Trailers.ToList();
    }

    public void Update(Trailer trailer)
    {
        _context.Trailers.Update(trailer);
    }

    public void Delete(int id)
    {
        var trailer = GetById(id);
        if (trailer != null)
        {
            _context.Trailers.Remove(trailer);
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}