using System;

namespace Shopitas.Domain
{
    public class Payment
    {
        public long AuthorizationNumber { get; }
        public decimal Amount { get; }
        public Invoice Invoice { get; set; }
        public PaymentMethod PaymentMethod { get; }
        public DateTime PaidAt { get; }

        public Payment(PaymentMethod paymentMethod, DateTime paidAt, Order order)
        {
            PaymentMethod = paymentMethod;
            PaidAt = paidAt;
            AuthorizationNumber = paidAt.Ticks;
            Amount = order.TotalAmount;
            GenerateInvoice(order);
        }

        private void GenerateInvoice(Order order)
        {
            var billingAddress = order.Address;
            var shippingAddress = order.Address;
            Invoice = new Invoice(billingAddress, shippingAddress, order);
        }
    }
}
