using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;

namespace server.Data;

public class DataSeeder : IEntityTypeConfiguration<Car>,
                         IEntityTypeConfiguration<Customer>,
                         IEntityTypeConfiguration<Rental>,
                         IEntityTypeConfiguration<Payment>,
                         IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(
            new Car { CarId = 1, Make = "Toyota", Model = "Camry", Year = 2020, PricePerDay = 50.00m, Status = CarStatus.Available },
            new Car { CarId = 2, Make = "Honda", Model = "Civic", Year = 2021, PricePerDay = 45.00m, Status = CarStatus.Available },
            new Car { CarId = 3, Make = "BMW", Model = "X5", Year = 2022, PricePerDay = 80.00m, Status = CarStatus.Maintenance },
            new Car { CarId = 4, Make = "Mercedes", Model = "C-Class", Year = 2021, PricePerDay = 75.00m, Status = CarStatus.Rented }
        );
    }

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer { Id = 1, Name = "John", Email = "john@example.com", Phone = "+1234567890" },
            new Customer { Id = 2, Name = "Jane", Email = "jane@example.com", Phone = "+1234567891" },
            new Customer { Id = 3, Name = "Mike", Email = "mike@example.com", Phone = "+1234567892" },
            new Customer { Id = 4, Name = "Sarah", Email = "sarah@example.com", Phone = "+1234567893" }
        );
    }

    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasData(
            new Rental { Id = 1, CustomerId = 1, CarId = 1, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 5), TotalAmount = 250.00m },
            new Rental { Id = 2, CustomerId = 2, CarId = 2, StartDate = new DateTime(2024, 3, 10), EndDate = new DateTime(2024, 3, 15), TotalAmount = 225.00m },
            new Rental { Id = 3, CustomerId = 3, CarId = 4, StartDate = new DateTime(2024, 3, 20), EndDate = new DateTime(2024, 3, 25), TotalAmount = 375.00m },
            new Rental { Id = 4, CustomerId = 4, CarId = 3, StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2024, 4, 5), TotalAmount = 320.00m }
        );
    }

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasData(
            new Payment { Id = 1, RentalId = 1, PaymentDate = new DateTime(2024, 3, 1), Amount = 250.00m, PaymentMethod = "CreditCard" },
            new Payment { Id = 2, RentalId = 2, PaymentDate = new DateTime(2024, 3, 10), Amount = 225.00m, PaymentMethod = "PayPal" },
            new Payment { Id = 3, RentalId = 3, PaymentDate = new DateTime(2024, 3, 20), Amount = 375.00m, PaymentMethod = "Cash" },
            new Payment { Id = 4, RentalId = 4, PaymentDate = new DateTime(2024, 4, 1), Amount = 320.00m, PaymentMethod = "CreditCard" }
        );
    }

    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(
            new Review { Id = 1, CustomerId = 1, CarId = 1, Rating = 5, Comment = "Excellent car, very comfortable!" },
            new Review { Id = 2, CustomerId = 2, CarId = 2, Rating = 4, Comment = "Good car, but a bit small." },
            new Review { Id = 3, CustomerId = 3, CarId = 4, Rating = 5, Comment = "Luxury car, amazing experience!" },
            new Review { Id = 4, CustomerId = 4, CarId = 3, Rating = 3, Comment = "Car was in maintenance, but service was good." }
        );
    }
}