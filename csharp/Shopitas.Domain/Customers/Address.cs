namespace Shopitas.Domain
{
    public class Address
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
    }
}