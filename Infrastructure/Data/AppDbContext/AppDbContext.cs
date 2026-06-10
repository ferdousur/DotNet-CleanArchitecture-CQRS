using CleanMediator.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMediator.Infrastructure.Data.AppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        
    }
    public DbSet<Category> Categories {get;set;}
    public DbSet<Product> Products {get;set;}
}
