using Microsoft.EntityFrameworkCore;
using RetailStore.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=BT-2205200\\SQLEXPRESS;Database=RetailStoreDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
    }
}
