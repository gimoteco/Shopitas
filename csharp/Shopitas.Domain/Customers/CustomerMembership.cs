using Shopitas.Domain.Base;
using Shopitas.Domain.Products;

namespace Shopitas.Domain.Customers
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