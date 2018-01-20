namespace Shopitas.Domain
{
    public interface MailSender
    {
        void Send(string mail, string message);
    }
}