using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Car
{
    [Key]
    public int CarId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Make { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PricePerDay { get; set; }

    [Required]
    public CarStatus Status { get; set; } = CarStatus.Available;

    // Navigation properties
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

public enum CarStatus
{
    Available,
    Rented,
    Maintenance
}