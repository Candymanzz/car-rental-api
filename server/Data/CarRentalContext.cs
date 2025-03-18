using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Models;

namespace server.Data;

public class CarRentalContext : DbContext
{
    public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships and constraints
        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Rental)
            .WithMany(r => r.Payments)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}