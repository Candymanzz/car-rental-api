using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [Required]
    public int RentalId { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    [Required]
    public PaymentMethod PaymentMethod { get; set; }

    // Navigation property
    [ForeignKey("RentalId")]
    public virtual Rental Rental { get; set; } = null!;
}

public enum PaymentMethod
{
    CreditCard,
    Cash,
    PayPal
}