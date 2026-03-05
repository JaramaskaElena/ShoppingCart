namespace ShoppingCart.ShoppingCart.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public List<CartItem> Items { get; set; } = new();
    }
}
