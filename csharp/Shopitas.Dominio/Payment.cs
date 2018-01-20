using System;

namespace Shopitas.Domain
{
    // TODO: Is really a payment even if wasn't paid yet?
    public class Payment
    {
        public long AuthorizationNumber { get; private set; }
        public decimal Amount { get; private set; }
        public Invoice Invoice { get; private set; }
        public PaymentMethod PaymentMethod { get; }
        public DateTime? PaidAt { get; private set; }
        public Order Order { get; }
        public bool IsPaid => PaidAt.HasValue;
        
        public Payment(Order order, PaymentMethod paymentMethod)
        {
            // TODO: Constructor with optional parameters
            Order = order;
            PaymentMethod = paymentMethod;
        }

        public void Pay(DateTime? paidAt = null) 
        {
            // TODO: C# design: Default parameter value should be compiling time constant
            PaidAt = paidAt ?? DateTime.Now;
            AuthorizationNumber = PaidAt.Value.Ticks;
            // TODO: Encapsulate better these commands
            Amount = Order.TotalAmount;

            // TODO: Using same addresses to both fields
            var billingAddress = Order.Address;
            var shippingAddress = Order.Address;
            Invoice = new Invoice(billingAddress, shippingAddress, Order);

            // TODO: Temporal coupling with PaidAt
            Order.Close(PaidAt.Value);
        }
    }
}
