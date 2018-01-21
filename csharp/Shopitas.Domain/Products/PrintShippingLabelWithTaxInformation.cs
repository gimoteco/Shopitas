using Shopitas.Domain.Base;

namespace Shopitas.Domain
{
    public class PrintShippingLabelWithTaxInformation : DomainEventHandler<BookSold>
    {
        private readonly Printer _printer;

        public PrintShippingLabelWithTaxInformation(Printer printer)
        {
            _printer = printer;
        }

        public void Handle(BookSold domainEvent)
        {
            _printer.Print($"{domainEvent.Address} - {domainEvent.TaxInformation}");
        }
    }
}