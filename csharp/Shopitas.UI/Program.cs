using System;
using Shopitas.Domain;

namespace Shopitas.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var foolano = new Customer();
            var book = new Product("Awesome book", "book");
            var bookOrder = new Order(foolano, null, null);
            bookOrder.AddProduct(book);
            var paymentBook = new Payment(bookOrder, CreditCard.FetchByHashed("43567890-987654367"));
            paymentBook.Pay();
            Console.WriteLine(paymentBook.IsPaid);
            Console.WriteLine(paymentBook.Order.Items[0].Product.Type);
        }
    }
}
