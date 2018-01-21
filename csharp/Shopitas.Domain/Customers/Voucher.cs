using Shopitas.Domain.Base;

namespace Shopitas.Domain.Customers
{
    public class Voucher: Entity
    {
        public bool Used { get; }
        public decimal Value { get; }

        public Voucher(decimal value)
        {
            Used = false;
            Value = value;
        }
    }
}