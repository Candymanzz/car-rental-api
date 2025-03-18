using server.Models;

namespace server.DTOs;

public class PaymentDto
{
    public int PaymentId { get; set; }
    public int RentalId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}