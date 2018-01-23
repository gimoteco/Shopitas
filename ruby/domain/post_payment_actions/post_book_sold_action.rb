class PostBookSoldAction
    def initialize(printer)
        @printer = printer
    end

    def execute(item, order)
        @printer.print("#{item.product.name}: item isento de impostos conforme disposto na Constituição Art. 150, VI, d.")
    end
end