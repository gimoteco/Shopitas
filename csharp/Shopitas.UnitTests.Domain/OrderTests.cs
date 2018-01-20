using System;
using System.Linq;
using NSubstitute;
using Shopitas.Domain;
using Shopitas.Domain.Base;
using Xunit;

namespace Shopitas.UnitTests.Domain
{
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly Address _address;
        private readonly Membership _membership;
        private readonly CreditCard _paymentMethod;

        public OrderTests()
        {
            DomainEventNotifier.CurrentNotifier = Substitute.For<DomainEventNotifier>();
            _customer = new Customer("gimoteco@gmail.com");
            _address = new Address("79042-656");
            _membership = new Membership("Premium service");
            _paymentMethod = CreditCard.FetchByHashed("123");    
        }

        [Fact]
        public void A_membership_order_payment_should_activate_the_membership()
        {
            var order = new Order(_customer, _address);
            order.AddProduct(_membership);

            order.Pay(_paymentMethod);

            var customerMembership = order.Customer.Memberships.First();
            Assert.True(customerMembership.Activated);
        }

        [Fact]
        public void Should_pay_an_order_and_register_the_date()
        {
            var order = new Order(_customer, _address);
            order.AddProduct(_membership);

            order.Pay(_paymentMethod);

            Assert.True(order.IsPaid);
            DateTimeAssert.Equal(DateTime.Now, order.Payment.PaidAt, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Should_close_an_order_after_payment()
        {
            var order = new Order(_customer, _address);
            order.AddProduct(_membership);

            order.Pay(_paymentMethod);
            
            DateTimeAssert.Equal(DateTime.Now, order.ClosedAt.Value, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void A_paid_order_should_register_payment_data()
        {
            var order = new Order(_customer, _address);
            order.AddProduct(_membership);

            order.Pay(_paymentMethod);

            Assert.NotNull(order.Payment);
        }
    }
}