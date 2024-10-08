using Microsoft.EntityFrameworkCore;
using MyTrailer.Domain.Aggregates;
using MyTrailer.Domain.Entities;
using MyTrailer.Domain.ValueObjects;

namespace MyTrailer.Infrastructure.Persistence;
public class MyTrailerDbContext(DbContextOptions<MyTrailerDbContext> options) : DbContext(options)
{
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Rental> Rentals { get; set; } // Aggregate root
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>(builder =>
        {
            builder.OwnsOne(r => r.Price, priceBuilder =>
            {
                priceBuilder.Property(p => p.Amount)
                    .HasColumnName("TotalPrice"); // Specify the column name in the database
            });
        });
    }
}