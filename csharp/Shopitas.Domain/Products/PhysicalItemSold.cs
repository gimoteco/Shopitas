using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class PhysicalItemSold: DomainEvent
    {
        public Address Address { get; }

        public PhysicalItemSold(Address address)
        {
            Address = address;
        }
    }
}