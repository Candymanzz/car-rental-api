namespace server.DTOs;

public record ReviewDto(
    int ReviewId,
    int CustomerId,
    int CarId,
    int Rating,
    string? Comment
);