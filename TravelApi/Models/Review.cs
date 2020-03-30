using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    [Required]
    [StringLength(100)]
    public string Destination { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
    public int Rating { get; set; }
    [Required]
    [StringLength(200)]
    public string Description { get; set; }
    [Required]
    [StringLength(50)]
    public string City { get; set; }
    [Required]
    [StringLength(50)]
    public string Country { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}