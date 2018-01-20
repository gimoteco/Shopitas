using System;
using Shopitas.Domain;

namespace Shopitas.Infrastructure
{
    public class FakeMailSender: MailSender
    {
        public void Send(string mail, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Mail sent to {mail}: {message}");
            Console.ResetColor();
        }
    }
}