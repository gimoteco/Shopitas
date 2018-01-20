namespace Shopitas.Domain
{
    public class CreditCard: PaymentMethod
    {
        public static CreditCard FetchByHashed(string code)
        {
            return new CreditCard();
        }
    }
}