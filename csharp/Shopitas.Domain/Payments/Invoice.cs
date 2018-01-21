using Shopitas.Domain.Customers;
using Shopitas.Domain.Orders;

namespace Shopitas.Domain.Payments
{
    public class Invoice
    {
        public Invoice(Address billingAddress, Address shippingAddress, Order order)
        {
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Order = order;
        }

        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public Order Order { get; }
    }
}