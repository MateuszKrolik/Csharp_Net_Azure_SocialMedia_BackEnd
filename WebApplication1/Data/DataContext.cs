using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Place> Places { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Place>()
            .OwnsOne(place => place.PlaceLocation);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(user => user.Places)
            .WithOne() // 1:n
            .HasForeignKey(place => place.Creator);
    }

}
