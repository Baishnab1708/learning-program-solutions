using System;

namespace EcommerceSearchExample
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return ProductName.CompareTo(other.ProductName);
        }
    }

    class Program
    {
        static Product? LinearSearch(Product[] products, string searchName)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        static Product? BinarySearch(Product[] sortedProducts, string searchName)
        {
            int left = 0, right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(sortedProducts[mid].ProductName, searchName, true);

                if (comparison == 0)
                    return sortedProducts[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Shoes", "Footwear"),
                new Product(103, "Mobile", "Electronics"),
                new Product(104, "Notebook", "Stationery"),
                new Product(105, "Backpack", "Bags")
            };

            Console.WriteLine("== Linear Search ==");
            var result1 = LinearSearch(products, "Mobile");
            Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Not found");

            Console.WriteLine("\n== Binary Search ==");
            Array.Sort(products);
            var result2 = BinarySearch(products, "Mobile");
            Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Not found");

            Console.WriteLine("\n== Time Complexity Analysis ==");
            Console.WriteLine("Linear Search: O(n) in all cases");
            Console.WriteLine("Binary Search: O(log n) in best, average, and worst case (on sorted data)");

            Console.WriteLine("\n== Conclusion ==");
            Console.WriteLine("Use Binary Search for large, sorted datasets for better performance.");
            Console.WriteLine("Use Linear Search for small or unsorted datasets.");
        }
    }
}
