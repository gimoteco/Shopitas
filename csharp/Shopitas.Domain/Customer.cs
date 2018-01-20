using System.Collections.Generic;
using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class Customer
    {
        public string Mail { get; }
        public IList<CustomerMembership> Memberships { get; }

        public Customer(string mail)
        {
            Mail = mail;
            Memberships = new List<CustomerMembership>();
        }

        public void ActivateMembership(Membership membership)
        {
            var customerMembership = new CustomerMembership(membership, this);
            customerMembership.Activate();
            Memberships.Add(customerMembership);

            DomainEventNotifier.CurrentNotifier.NotifyAbout(new MembershipActivated(this));
        }
    }
}