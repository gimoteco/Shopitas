namespace Shopitas.Domain
{
    public class PhysicalItem: Product
    {
        public PhysicalItem(string name) : base(name)
        {
        }

        public override void Deliver(Order order)
        {
            order.Ship();
        }
    }
}