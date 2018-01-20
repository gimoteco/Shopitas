using System;
using System.Collections.Generic;
using Shopitas.Domain;
using Shopitas.Domain.Base;

namespace Shopitas.Infrastructure
{
    public class FakeDomainEventNotifier: DomainEventNotifier
    {
        private readonly Dictionary<Type, object> _eventToHandlers = new Dictionary<Type, object>();

        public FakeDomainEventNotifier()
        {
            var fakeMailSender = new FakeMailSender();
            var notifyCustomerMembershipWasActivated = new NotifyCustomerMembershipWasActivated(fakeMailSender);
            _eventToHandlers.Add(typeof(MembershipActivated), notifyCustomerMembershipWasActivated);
        }

        public override void NotifyAbout<T>(T domainEvent)
        {
            var eventToHandler = (DomainEventHandler<T>) _eventToHandlers[domainEvent.GetType()];
            eventToHandler.Handle(domainEvent);
        }
    }
}