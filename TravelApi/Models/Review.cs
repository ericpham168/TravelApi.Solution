using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    [Required]
    [Range(0, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
    public int Rating { get; set; }
    [Required]
    [StringLength(200)]
    public string Description { get; set; }
    public int LocationId { get; set; }
    public virtual Location Location { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}