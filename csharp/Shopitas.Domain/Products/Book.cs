using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class Book: Product
    {
        public Book(string name) : base(name)
        {
        }

        public override void Deliver(Order order)
        {
            const string taxInformation = "Item isento de impostos conforme disposto na Constituição Art. 150, VI, d.";
            var shippingAddress = order.Payment.Invoice.ShippingAddress;
            DomainEventNotifier.CurrentNotifier.NotifyAbout(new BookSold(shippingAddress, taxInformation));
        }
    }
}