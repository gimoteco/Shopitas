using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class BookSold : DomainEvent
    {
        public Address Address { get; }
        public string TaxInformation { get; }

        public BookSold(Address address, string taxInformation)
        {
            Address = address;
            TaxInformation = taxInformation;
        }
    }
}