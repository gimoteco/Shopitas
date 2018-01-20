﻿using Shopitas.Domain;

namespace Shopitas.UnitTests.Domain
{
    public class OrderBuilder
    {
        public static OrderBuilder New()
        {
            return new OrderBuilder();
        }

        public Order Create()
        {
            var address = new Address("79042-656");
            var customer = new Customer();
            var order = new Order(customer, address);
            return order;
        }
    }
}