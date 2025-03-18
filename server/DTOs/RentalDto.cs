namespace server.DTOs;

public record RentalDto(
    int RentalId,
    int CustomerId,
    int CarId,
    DateTime RentalStartDate,
    DateTime RentalEndDate,
    decimal TotalPrice
);