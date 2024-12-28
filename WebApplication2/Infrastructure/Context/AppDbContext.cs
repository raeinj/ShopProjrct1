using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Models;

namespace WebApplication2.Infrastructure.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
   
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

}