using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class DigitalMedia: Product
    {
        public DigitalMedia(string name) : base(name)
        {
        }

        public override void Deliver(Order order)
        {
            const decimal promotionalVoucherValue = 10;
            order.GiveAVoucherOf(promotionalVoucherValue);

            var digitalMediaSold = new DigitalMediaSold(order.Customer, this);
            DomainEventNotifier.CurrentNotifier.NotifyAbout(digitalMediaSold);
        }
    }
}