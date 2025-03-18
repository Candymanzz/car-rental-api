using server.Models;

namespace server.DTOs;

public record PaymentDto(
    int PaymentId,
    int RentalId,
    DateTime PaymentDate,
    decimal Amount,
    PaymentMethod PaymentMethod
);