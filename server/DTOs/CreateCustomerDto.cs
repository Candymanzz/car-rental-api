namespace server.DTOs;

public record CreateCustomerDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone
);