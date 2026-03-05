using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Helper
{
    public static class ProductCatalog
    {
        public static List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500 },
        new Product { Id = 2, Name = "Phone", Price = 800 },
        new Product { Id = 3, Name = "Keyboard", Price = 100 },
        new Product { Id = 4, Name = "Mouse", Price = 50 }
    };

        public static Product? GetById(int id)
        {
          return  Products.FirstOrDefault(p => p.Id == id);
        }
    }
}