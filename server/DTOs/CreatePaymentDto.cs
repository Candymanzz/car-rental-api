using server.Models;

namespace server.DTOs;

public record CreatePaymentDto(
    int RentalId,
    DateTime PaymentDate,
    decimal Amount,
    PaymentMethod PaymentMethod
);