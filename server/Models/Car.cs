using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Brand { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal DailyRate { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    [Required]
    [MaxLength(100)]
    public string Color { get; set; } = string.Empty;

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