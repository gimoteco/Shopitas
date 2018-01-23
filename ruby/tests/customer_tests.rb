require 'test/unit'
require_relative '../domain/customers'

class CustomerTests <  Test::Unit::TestCase
    MAIL = 'gimoteco@gmail.com'

    def test_customer_should_begin_with_no_memberships
        customer = Customer.new MAIL

        assert_true customer.memberships.empty?
    end

    def test_should_activate_a_membership        
    end

    def test_customer_should_begin_with_no_vouchers
        customer = Customer.new MAIL
        
        assert_true customer.vouchers.empty?
    end

    def test_customer_should_record_the_voucher
        customer = Customer.new MAIL
        amount = 10

        customer.give_a_voucher_of(amount)
        
        assert_equal 1, customer.vouchers.length
        assert_equal amount, customer.vouchers[0].value
    end
end