using NSubstitute;
using Shopitas.Domain;
using Shopitas.Domain.Base;
using Xunit;

namespace Shopitas.UnitTests.Domain
{
    public class CustomerMembershipTests
    {
        private readonly Customer _customer;
        private readonly Membership _membership;

        public CustomerMembershipTests()
        {
            DomainEventNotifier.CurrentNotifier = Substitute.For<DomainEventNotifier>();
            _customer = new Customer("gimoteco@gmail.com");
            _membership = new Membership("Premium membership");
        }

        [Fact]
        public void Membership_should_be_created_inactive()
        {
            var customerMembership = new CustomerMembership(_membership, _customer);

            Assert.False(customerMembership.Activated);
        }

        [Fact]
        public void Should_activate_a_membership()
        {
            var customerMembership = new CustomerMembership(_membership, _customer);

            customerMembership.Activate();

            Assert.True(customerMembership.Activated);
        }
    }
}