require 'test/unit'
require_relative '../domain/customers';
require_relative '../domain/orders';
require_relative '../domain/products';

class PaymentTests <  Test::Unit::TestCase
    def test_that_payment_should_generate_the_invoice_using_the_address_in_order
        payment_method = CreditCard.fetch_by_hashed '123'
        customer = Customer.new 'gimoteco@gmail.com'
        order = Order.new(customer)
        expected_invoice = Invoice.new(order)

        payment = Payment.new(payment_method, Time.now, order)

        assert_equal order.address, payment.invoice.billing_address
        assert_equal order.address, payment.invoice.shipping_address
    end
end