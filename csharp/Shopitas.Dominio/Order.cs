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
        public Type OrderItemClass { get; }
        public List<OrderItem> Items { get; }
        public DateTime? ClosedAt { get; private set; }

        public Order(Customer customer, Type orderItemClass, Address address)
        {
            // TODO: Using reflection for initializing OrderItem
            Customer = customer;
            OrderItemClass = orderItemClass ?? typeof(OrderItem);
            Items = new List<OrderItem>();
            Address = address ?? new Address("45678-979");
        }

        public void AddProduct(Product product)
        {
            // TODO: Using reflection for initializing OrderItem
            var constructor = OrderItemClass.GetConstructor(new [] {typeof(Order), typeof(Product)});
            var item = (OrderItem) constructor.Invoke(new object[] {this, product});
            Items.Add(item);
        }

        public void Close(DateTime closedAt)
        {
            ClosedAt = closedAt;
        }
    }
}