using System;
using System.Collections.Generic;
using System.Linq;
using Shopitas.Domain.Base;

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
        public ShippingLabel ShippingLabel { get; set; }

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
            DeliverItems();
        }

        public void Pay(PaymentMethod paymentMethod)
        {
            var now = DateTime.Now;
            RegisterPayment(paymentMethod, now);
            Close(now);
        }

        private void RegisterPayment(PaymentMethod paymentMethod, DateTime now)
        {
            var payment = new Payment(paymentMethod, now, this);
            Payment = payment;
        }

        private void DeliverItems()
        {
            Items.ForEach(item => item.Deliver());
        }

        public void GiveAVoucherOf(decimal value)
        {
            Customer.GiveAVoucherOf(value);
        }
    }
}