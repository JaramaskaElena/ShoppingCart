using ShoppingCart.ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartService
    {
            Task<Cart?> GetCartAsync(int userId);
            Task AddItemAsync(int userId, int productId, int quantity);
            Task RemoveItemAsync(int userId, int productId);
            Task ClearCartAsync(int userId);
            Task DeleteCartAsync(int userId);
        }
    }