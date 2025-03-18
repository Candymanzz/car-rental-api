using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Rental
{
    [Key]
    public int RentalId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    public DateTime RentalStartDate { get; set; }

    [Required]
    public DateTime RentalEndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalPrice { get; set; }

    // Navigation properties
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}