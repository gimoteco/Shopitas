using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopitas.Domain
{
    public class Order
    {
        public Customer Customer { get; }
        public decimal TotalAmount => Items.Sum(item => item.Total);
        public Address Address { get; }
        public List<OrderItem> Items { get; }
        public DateTime? ClosedAt { get; private set; }
        public Payment Payment { get; private set; }
        public bool IsPaid => Payment != null;
        
        public Order(Customer customer, Address address)
        {
            Customer = customer;
            Items = new List<OrderItem>();
            Address = address;
        }

        public void AddProduct(Product product)
        {
            var item = new OrderItem(this, product);
            Items.Add(item);
        }

        public void Close(DateTime closedAt)
        {
            ClosedAt = closedAt;
        }

        public void Pay(PaymentMethod paymentMethod)
        {
            var now = DateTime.Now;
            var payment = new Payment(paymentMethod, now, this);
            Payment = payment;

            DeliverItems();

            Close(now);
        }

        private void DeliverItems()
        {
            Items.ForEach(item => item.Deliver(Customer));
        }
    }
}