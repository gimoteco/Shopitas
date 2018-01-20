using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class CustomerMembership: Entity
    {
        public bool Activated { get; set; }
        public Membership Membership { get; }
        public Customer Customer { get; }

        public CustomerMembership(Membership membership, Customer customer)
        {
            Membership = membership;
            Customer = customer;
            Activated = false;
        }

        public void Activate()
        {
            Activated = true;
        }
    }
}