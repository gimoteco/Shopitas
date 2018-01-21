namespace Shopitas.Domain
{
    public class OrderItem
    {
        public decimal Total => 10;
        public Order Order { get; }
        public Product Product { get; }

        public OrderItem(Order order, Product product)
        {
            Order = order;
            Product = product;
        }

        public void Deliver()
        {
            Product.Deliver(Order);
        }
    }
}