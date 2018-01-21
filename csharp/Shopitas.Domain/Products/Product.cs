using Shopitas.Domain.Base;

namespace Shopitas.Domain.Products
{
    public class Product: Entity
    {
        public string Name { get; }
        public ProductType Type { get; }

        protected Product(string name, ProductType type)
        {
            Name = name;
            Type = type;
        }
    }
}