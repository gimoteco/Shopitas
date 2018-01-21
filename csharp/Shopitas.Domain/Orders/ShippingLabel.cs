using Shopitas.Domain.Base;
using Shopitas.Domain.Customers;

namespace Shopitas.Domain.Orders
{
    public class ShippingLabel: ValueObject
    {
        public Address Address { get; }
        public string TaxInformation { get; }

        public ShippingLabel(string taxInformation, Address address)
        {
            TaxInformation = taxInformation;
            Address = address;
        }

        public ShippingLabel(Address address)
        {
            Address = address;
        }

        protected override string EqualityExpressionText => $"{Address},{TaxInformation}";
    }
}