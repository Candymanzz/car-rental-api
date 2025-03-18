namespace server.DTOs;

public record CreateRentalDto(
    int CustomerId,
    int CarId,
    DateTime RentalStartDate,
    DateTime RentalEndDate,
    decimal TotalPrice
);