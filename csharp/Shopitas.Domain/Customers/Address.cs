using Shopitas.Domain.Base;

namespace Shopitas.Domain.Customers
{
    public class Address: ValueObject
    {
        public string Zipcode { get; }

        public Address(string zipcode)
        {
            Zipcode = zipcode;
        }

        public override string ToString()
        {
            return $"Zipcode: {Zipcode}";
        }

        protected override string EqualityExpressionText => $"{Zipcode}";
    }
}