namespace Shopitas.Domain
{
    public class Voucher
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