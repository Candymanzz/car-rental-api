using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RentalId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;

    // Navigation property
    public virtual Rental Rental { get; set; } = null!;
}

public enum PaymentMethod
{
    CreditCard,
    Cash,
    PayPal
}