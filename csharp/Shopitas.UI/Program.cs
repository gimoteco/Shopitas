using System;
using System.Linq;
using Shopitas.Domain;
using Shopitas.Domain.Base;
using Shopitas.Infrastructure;

namespace Shopitas.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            DomainEventNotifier.CurrentNotifier = new FakeDomainEventNotifier();
            var foolano = new Customer("gimoteco@gmail.com");
            var book = new Book("Awesome book");
            var broom = new PhysicalItem("Broom");
            var membership = new Membership("Premium account");
            var address = new Address("79042-656");
            var digitalMedia = new DigitalMedia("AwesomeBook.epub");

            var order = new Order(foolano, address);
            order.AddProduct(book);
            order.AddProduct(broom);
            order.AddProduct(membership);
            order.AddProduct(digitalMedia);
            var fetchByHashed = CreditCard.FetchByHashed("43567890-987654367");
            order.Pay(fetchByHashed);

            Console.WriteLine(order.IsPaid);
            Console.WriteLine(order.Items[0].Product);
            Console.WriteLine(foolano.Memberships.First().Activated);
        }
    }
}
