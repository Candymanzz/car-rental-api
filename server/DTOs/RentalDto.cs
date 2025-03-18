namespace server.DTOs;

public class RentalDto
{
    public int RentalId { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public DateTime RentalStartDate { get; set; }
    public DateTime RentalEndDate { get; set; }
    public decimal TotalPrice { get; set; }
}