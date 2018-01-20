namespace Shopitas.Domain
{
    public class OrderItem
    {
        // TODO: Hard coded magic number
        public decimal Total => 10;
        public Order Order { get; }
        public Product Product { get; }

        public OrderItem(Order order, Product product)
        {
            Order = order;
            Product = product;
        }
    }
}