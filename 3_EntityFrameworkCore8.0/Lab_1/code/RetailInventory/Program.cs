using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore; // ✅ Add this line

using var context = new InventoryContext();

if (!context.Categories.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    context.Categories.AddRange(electronics, groceries);

    context.Products.AddRange(
        new Product { Name = "TV", Category = electronics, Stock = 10 },
        new Product { Name = "Rice", Category = groceries, Stock = 50 }
    );

    context.SaveChanges();
}

Console.WriteLine("Categories and Products:");
foreach (var category in context.Categories.Include(c => c.Products))
{
    Console.WriteLine($"- {category.Name}");
    foreach (var product in category.Products)
    {
        Console.WriteLine($"  - {product.Name} (Stock: {product.Stock})");
    }
}
