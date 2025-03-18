namespace server.DTOs;

public record CreateReviewDto(
    int CustomerId,
    int CarId,
    int Rating,
    string? Comment
);