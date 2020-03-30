using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Location
  {
    public Location()
    {
      this.Reviews = new HashSet<Review>();
    }
    public int LocationId { get; set; }
    [Required]
    [StringLength(50)]
    public string Country { get; set; }
    [Required]
    [StringLength(50)]
    public string City { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
  }
}