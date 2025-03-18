using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}