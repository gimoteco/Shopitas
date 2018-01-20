using System.Collections.Generic;

namespace Shopitas.Domain
{
    public class Customer
    {
        public IList<CustomerMembership> Memberships { get; }

        public Customer()
        {
            Memberships = new List<CustomerMembership>();
        }

        public void AddMembership(Membership membership)
        {
            var customerMembership = new CustomerMembership(membership, this);
            customerMembership.Activate();
            Memberships.Add(customerMembership);
        }
    }
}