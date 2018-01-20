using System;

namespace Shopitas.Domain
{
    public class Membership: Product
    {
        public Membership(string name) : base(name)
        {
        }

        public override void Deliver(Customer customer)
        {
            customer.AddMembership(this);
        }
    }
}