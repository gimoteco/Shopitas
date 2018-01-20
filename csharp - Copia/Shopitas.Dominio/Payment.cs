using System;

namespace Shopitas.Domain
{
    public class Payment
    {
        public long AuthorizationNumber { get; }
        public decimal Amount { get; }
        public Invoice Invoice { get; }
        public PaymentMethod PaymentMethod { get; }
        public DateTime PaidAt { get; }

        public Payment(PaymentMethod paymentMethod, DateTime paidAt, Order order)
        {
            PaymentMethod = paymentMethod;
            PaidAt = paidAt;
            AuthorizationNumber = paidAt.Ticks;
            Amount = order.TotalAmount;

            var billingAddress = order.Address;
            var shippingAddress = order.Address;
            Invoice = new Invoice(billingAddress, shippingAddress, order);
        }
    }
}
