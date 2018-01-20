namespace Shopitas.Domain
{
    public abstract class Product
    {
        public string Name { get; }

        protected Product(string name)
        {
            Name = name;
        }

        public abstract void Deliver(Customer customer);
    }
}