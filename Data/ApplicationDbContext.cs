using Customer_Information.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_Information.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : Customer_Information(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Customer_Information.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasMany<Address>(c => c.address)
            .WithOne(c => c.customer)
            .HasForeignKey(c => c.CustomerId)
           ;

    }
  public DbSet<Address> addresses { get; set; }
   public DbSet<Customer> customers { get; set; }
}
