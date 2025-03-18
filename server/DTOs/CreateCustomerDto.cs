namespace server.DTOs;

public record CreateCustomerDto(
    string Name,
    string Email,
    string Phone,
    string Address
);