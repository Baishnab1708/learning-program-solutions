
using Microsoft.EntityFrameworkCore;
using RetailStore.Models;

using var context = new AppDbContext();

if (!context.Categories.Any())
{
    var cat = new Category { Name = "Appliances" };
    context.Categories.Add(cat);
    context.Products.Add(new Product { Name = "Microwave", Price = 4500, Category = cat });
    context.SaveChanges();
}

Console.WriteLine("Stored Data:");
foreach (var category in context.Categories.Include(c => c.Products))
{
    Console.WriteLine($"- {category.Name}");
    foreach (var product in category.Products)
    {
        Console.WriteLine($"  - {product.Name}: ₹{product.Price}");
    }
}
