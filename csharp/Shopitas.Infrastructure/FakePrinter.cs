using System;
using Shopitas.Domain;

namespace Shopitas.Infrastructure
{
    public class FakePrinter : Printer
    {
        public void Print(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Printed in printer: {message}");
            Console.ResetColor();
        }
    }
}