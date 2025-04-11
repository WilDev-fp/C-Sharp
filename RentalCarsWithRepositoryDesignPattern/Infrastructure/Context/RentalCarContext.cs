using Microsoft.EntityFrameworkCore;
using RentalCarsWithRepositoryDesignPattern.Domain.Model;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

public class RentalCarContext : DbContext
{
    public DbSet<Automobile> Automobile { get; set; }
    public DbSet<Rental> Rental { get; set; }
    public DbSet<UserClient> UserClient { get; set; }

    public RentalCarContext(DbContextOptions<RentalCarContext> options) : base (options)
    {
        Database.EnsureCreated();
    }
}
