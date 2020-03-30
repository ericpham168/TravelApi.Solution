using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class TravelApiContext : DbContext
  {
    public TravelApiContext(DbContextOptions<TravelApiContext> options)
      : base(options)
    {
    }
    
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Review>()
        .HasData(
          new Review { ReviewId = 1, Author = "Michelle", Destination = "Louvre", Rating = 3, Description = "too crowded, some cool art", City = "Paris", Country = "France" },
          new Review { ReviewId = 2, Author = "Joe", Destination = "Irazu volcano national park", Rating = 4, Description = "it's a volcano", City = "Cartago", Country = "Costa Rica" },
          new Review { ReviewId = 3, Author = "Cletus", Destination = "The sticks", Rating = 5, Description = "real nice", City = "Cedar Creek", Country = "Canada" },
          new Review { ReviewId = 4, Author = "James", Destination = "Da Club", Rating = 3, Description = "It was aight", City = "Sydney", Country = "Australia" }
        );
    }
  }
}