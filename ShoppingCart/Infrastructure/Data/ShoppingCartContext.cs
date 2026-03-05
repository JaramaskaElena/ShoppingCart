using Microsoft.EntityFrameworkCore;
using ShoppingCart.ShoppingCart.Domain.Entities;

namespace ShoppingCart.Infrastructure.Data
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(ci => ci.CartId);
        }
    }
}
