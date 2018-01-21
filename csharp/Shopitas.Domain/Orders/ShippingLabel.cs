namespace Shopitas.Domain
{
    public class ShippingLabel
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
    }
}