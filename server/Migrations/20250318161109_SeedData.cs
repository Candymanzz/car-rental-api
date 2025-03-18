using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Make", "Model", "PricePerDay", "Status", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "Camry", 50.00m, 0, 2020 },
                    { 2, "Honda", "Civic", 45.00m, 0, 2021 },
                    { 3, "BMW", "X5", 80.00m, 2, 2022 },
                    { 4, "Mercedes", "C-Class", 75.00m, 1, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "+1234567890" },
                    { 2, "jane@example.com", "Jane", "Smith", "+1234567891" },
                    { 3, "mike@example.com", "Mike", "Johnson", "+1234567892" },
                    { 4, "sarah@example.com", "Sarah", "Williams", "+1234567893" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentalId", "CarId", "CustomerId", "RentalEndDate", "RentalStartDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.00m },
                    { 2, 2, 2, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 225.00m },
                    { 3, 4, 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 375.00m },
                    { 4, 3, 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 320.00m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CarId", "Comment", "CustomerId", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Excellent car, very comfortable!", 1, 5 },
                    { 2, 2, "Good car, but a bit small.", 2, 4 },
                    { 3, 4, "Luxury car, amazing experience!", 3, 5 },
                    { 4, 3, "Car was in maintenance, but service was good.", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "PaymentDate", "PaymentMethod", "RentalId" },
                values: new object[,]
                {
                    { 1, 250.00m, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, 225.00m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 375.00m, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, 320.00m, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);
        }
    }
}
