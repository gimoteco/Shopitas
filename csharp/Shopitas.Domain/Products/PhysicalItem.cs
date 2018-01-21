using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class PhysicalItem: Product
    {
        public PhysicalItem(string name) : base(name)
        {
        }

        public override void Deliver(Order order)
        {
            var shippingAddress = order.Payment.Invoice.ShippingAddress;
            order.ShippingLabel = new ShippingLabel(shippingAddress);
            DomainEventNotifier.CurrentNotifier.NotifyAbout(new PhysicalItemSold(shippingAddress));
        }
    }
}