namespace Shopitas.Domain
{
    public class Book: Product
    {
        public Book(string name) : base(name)
        {
        }

        public override void Deliver(Customer customer)
        {
            
        }
    }
}