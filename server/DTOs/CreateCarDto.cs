using server.Models;

namespace server.DTOs;

public record CreateCarDto(
    string Make,
    string Model,
    int Year,
    decimal PricePerDay,
    CarStatus Status
);