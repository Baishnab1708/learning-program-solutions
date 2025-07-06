using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailStore;
using RetailStore.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        Console.WriteLine("\nAll Products:");
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        Console.WriteLine("\nFind Product with ID = 1:");
        var productById = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {productById?.Name ?? "Not Found"}");

        Console.WriteLine("\nFirst Product with Price > ₹50000:");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name ?? "Not Found"}");
    }
}
