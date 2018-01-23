class Customer
  attr_reader :mail, :memberships, :vouchers

  def initialize(mail)
    @mail = mail
    @memberships = []
    @vouchers = []
  end

  def give_a_voucher_of(value)
    @vouchers << Voucher.new(value)
  end
end
  
class Membership
end

class Voucher
  attr_reader :value, :used

  def initialize(value)
    @value = value
    @used = false
  end

  def used?
    @used
  end
end

class Address
    attr_reader :zipcode
  
    def initialize(zipcode:)
      @zipcode = zipcode
    end
end