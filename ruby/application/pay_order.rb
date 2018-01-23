require_relative '../domain/orders'
require_relative '../domain/customers'
require_relative '../domain/products'
require_relative '../domain/post_payment_actions/post_book_sold_action'

class PayOrder
    
    def initialize(mail_sender, printer, orders)
        @orders = orders
        @printer = printer
    end

    def pay(order_id, credit_card_hash)
        order = @orders.get_by(order_id)
        payment_method = CreditCard.fetch_by_hashed(credit_card_hash)

        order.pay payment_method

        execute_post_payment_actions order

        @orders.update(order);
    end

    def execute_post_payment_actions(order)
        actions = {"book" => PostBookSoldAction.new(@printer) }
        order.items.each { |item|
            actions[item.product.type].execute(item, order)
        }
    end
end

class OrderItems
    def initialize(orders)
        @orders = orders;
    end

    def order(customer_mail, items)
        customer = Customer.new(customer_mail)
        order = Order.new customer
        items.each {|item| order.add_product(Product.new(item["name"], item["type"]))}
        @orders.add(order);
        order
    end
end