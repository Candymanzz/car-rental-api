namespace server.DTOs;

public class ReviewDto
{
    public int ReviewId { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}