using ShoppingCart.ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICartRepository
    {
            Task<Cart?> GetByUserIdAsync(int userId);
            Task CreateAsync(Cart cart);
            Task UpdateAsync(Cart cart);
            Task DeleteAsync(int userId);
        }
    }