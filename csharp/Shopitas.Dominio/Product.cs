namespace Shopitas.Domain
{
    public class Product
    {
        public string Name { get; }
        public string Type { get; }

        public Product(string name, string type)
        {
            // TODO: Use enum for product type
            Name = name;
            Type = type;
        }
    }
}