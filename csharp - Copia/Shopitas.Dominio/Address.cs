namespace Shopitas.Domain
{
    public class Address
    {
        public string Zipcode { get; }

        public Address(string zipcode)
        {
            Zipcode = zipcode;
        }
    }
}