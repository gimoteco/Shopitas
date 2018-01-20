﻿using NSubstitute;
using Shopitas.Domain;
using Shopitas.Domain.Base;
using Xunit;

namespace Shopitas.UnitTests.Domain
{
    public class CustomerTests
    {
        private const string Mail = "gimoteco@gmail.com";

        public CustomerTests()
        {
            DomainEventNotifier.CurrentNotifier = Substitute.For<DomainEventNotifier>();
        }

        [Fact]
        public void Customer_should_require_a_mail()
        {
            var customer = new Customer(Mail);

            Assert.Equal(Mail, customer.Mail);
        }

        [Fact]
        public void Customer_should_be_created_with_no_subscriptions()
        {
            var customer = new Customer(Mail);

            Assert.Equal(0, customer.Memberships.Count);
        }

        [Fact]
        public void Should_add_a_membership_to_a_customer()
        {
            var customer = new Customer(Mail);
            var membership = new Membership("Premium membership");
            var expectedCustomerMemberships = new[] { new CustomerMembership(membership, customer) };

            customer.ActivateMembership(membership);

            Assert.Equal(expectedCustomerMemberships, customer.Memberships);
        }

        [Fact]
        public void Should_notify_the_customer_that_his_membership_was_activated()
        {
            var customer = new Customer(Mail);
            var membership = new Membership("Premium membership");
            var domainEventNotifier = Substitute.For<DomainEventNotifier>();
            DomainEventNotifier.CurrentNotifier = domainEventNotifier;

            customer.ActivateMembership(membership);

            domainEventNotifier.Received(1).NotifyAbout(Arg.Is<DomainEvent>(@event => @event is MembershipActivated));
        }
    }
}