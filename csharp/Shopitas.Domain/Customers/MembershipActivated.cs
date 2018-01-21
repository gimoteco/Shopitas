using Shopitas.Domain.Base;

namespace Shopitas.Domain.Customers
{
    public class MembershipActivated: DomainEvent
    {
        public Customer Customer { get; }

        public MembershipActivated(Customer customer)
        {
            Customer = customer;
        }
    }
}