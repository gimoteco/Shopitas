using Shopitas.Domain;
using Xunit;

namespace Shopitas.UnitTests.Domain
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_should_be_created_with_no_subscriptions()
        {
            var customer = new Customer();

            Assert.Equal(0, customer.Memberships.Count);
        }

        [Fact]
        public void Should_add_a_membership_to_a_user()
        {
            var customer = new Customer();
            var membership = new Membership("Premium membership");
            var expectedCustomerMemberships = new[] { new CustomerMembership(membership, customer) };

            customer.AddMembership(membership);

            Assert.Equal(expectedCustomerMemberships, customer.Memberships);
        }
    }
}