using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data;

public class InventoryContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RetailInventoryDb;Trusted_Connection=True;");
    }
}
