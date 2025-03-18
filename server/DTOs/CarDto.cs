using server.Models;

namespace server.DTOs;

public record CarDto(
    int CarId,
    string Make,
    string Model,
    int Year,
    decimal PricePerDay,
    CarStatus Status
);