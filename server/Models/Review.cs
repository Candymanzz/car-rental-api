using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Review
{
    [Key]
    public int ReviewId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    public string? Comment { get; set; }

    // Navigation properties
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; } = null!;
}