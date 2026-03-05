using ShoppingCart.Application.Helper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cart?> GetCartAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task AddItemAsync(int userId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var cart = await _repository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow
                };
                await _repository.CreateAsync(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = ProductCatalog.GetById(productId)
                              ?? throw new KeyNotFoundException("Product not found");

                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price
                });
            }

            await _repository.UpdateAsync(cart);
        }

        public async Task RemoveItemAsync(int userId, int productId)
        {
            var cart = await _repository.GetByUserIdAsync(userId);
            if (cart == null) throw new KeyNotFoundException("Cart not found");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) throw new KeyNotFoundException("Item not found");

            cart.Items.Remove(item);
            await _repository.UpdateAsync(cart);
        }

        public async Task ClearCartAsync(int userId)
        {
            var cart = await _repository.GetByUserIdAsync(userId);
            if (cart == null) throw new KeyNotFoundException("Cart not found");

            cart.Items.Clear();
            await _repository.UpdateAsync(cart);
        }

        public async Task DeleteCartAsync(int userId)
        {
            await _repository.DeleteAsync(userId);
        }
    }
}