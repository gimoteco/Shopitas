using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class DigitalMediaSold : DomainEvent
    {
        public Customer Customer { get; set; }
        public DigitalMedia Product { get; set; }

        public DigitalMediaSold(Customer customer, DigitalMedia product)
        {
            Customer = customer;
            Product = product;
        }
    }
}