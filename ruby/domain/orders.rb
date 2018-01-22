class Order
    attr_reader :customer, :items, :payment, :address, :closed_at
  
    def initialize(customer, overrides = {})
      @customer = customer
      @items = []
      @order_item_class = overrides.fetch(:item_class) { OrderItem }
      @address = overrides.fetch(:address) { Address.new(zipcode: '45678-979') }
    end
  
    def add_product(product)
      @items << @order_item_class.new(order: self, product: product)
    end
  
    def total_amount
      @items.map(&:total).inject(:+)
    end
  
    def close(closed_at = Time.now)
      @closed_at = closed_at
    end

    def is_closed?
      !@closed_at.nil?
    end

    def pay(payment_method)
      raise 'No items ordered' unless @items.any?
      register_payment payment_method
      close
    end

    def register_payment(payment_method)
      @payment = Payment.new payment_method, Time.now, self
    end

    def is_paid?
      !payment.nil?
    end
  end
  
  class OrderItem
    attr_reader :order, :product
  
    def initialize(order:, product:)
      @order = order
      @product = product
    end
  
    def total
      10
    end
end

class Payment
    attr_reader :authorization_number, :amount, :invoice, :order, :payment_method, :paid_at

    def initialize(payment_method, paid_at, order)
      @payment_method = payment_method;
      @paid_at = paid_at;
      @order = order;
      @amount = order.total_amount
      @authorization_number = Time.now.to_i
      generate_invoice
    end

    def generate_invoice()
      @invoice = Invoice.new(@order)
    end
  end
  
  class Invoice
    attr_reader :billing_address, :shipping_address, :order
  
    def initialize(order)
      @billing_address = order.address
      @shipping_address = order.address
      @order = order
    end
end

class CreditCard
    def self.fetch_by_hashed(code)
      CreditCard.new
    end
end
  
  
  