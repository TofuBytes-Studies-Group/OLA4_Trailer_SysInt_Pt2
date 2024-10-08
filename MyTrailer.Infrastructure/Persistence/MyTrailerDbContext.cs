using Microsoft.EntityFrameworkCore;
using MyTrailer.Domain.Aggregates;
using MyTrailer.Domain.Entities;

namespace MyTrailer.Infrastructure.Persistence;
public class MyTrailerDbContext(DbContextOptions<MyTrailerDbContext> options) : DbContext(options)
{
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize entity mappings here if necessary
    }
}