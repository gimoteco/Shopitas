namespace Shopitas.Domain
{
    public class DigitalMedia: Product
    {
        public DigitalMedia(string name) : base(name)
        {
        }

        public override void Deliver(Order order)
        {
        }
    }
}