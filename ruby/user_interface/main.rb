require_relative '../infrastructure/in_memory_orders'
require_relative '../infrastructure/console_printer'
require_relative '../application/pay_order'

in_memory_orders = InMemoryOrders.new
console_printer = ConsolePrinter.new

customer_mail = "gimoteco@gmail.com"
credit_card_hash = '123'
order_items = OrderItems.new(in_memory_orders)
pay_order = PayOrder.new(nil, console_printer, in_memory_orders)
items = [{"name" => "Harry Potter", "type" => "book"}]
order = order_items.order(customer_mail, items)
pay_order.pay(order.id, credit_card_hash)