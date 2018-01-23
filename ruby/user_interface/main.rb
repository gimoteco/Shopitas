require_relative '../application/in_memory_orders'
require_relative '../application/pay_order'

in_memory_orders = InMemoryOrders.new
customer_mail = "gimoteco@gmail.com"
credit_card_hash = '123'
order_items = OrderItems.new(in_memory_orders)
pay_order = PayOrder.new(nil, nil, in_memory_orders)
items = [{"name" => "Harry Potter", "type" => "book"}]
order = order_items.order(customer_mail, items)aa
pay_order.pay(order.id, credit_card_hash)
puts in_memory_orders.get_by(order.id).is_paid?