using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.0m },
            { "EUR", 0.95m },
            { "MXN", 17.0m },
            { "JPY", 150.0m },
            // Direct rate example .
            { "USD/GBP", 0.8m },
            // Inverse rate example (no direct USD/CHF, but CHF/USD exists).
            { "CHF/USD", 1.1m },
            // Add GBP as a base for intermediate test .
            { "GBP", 0.8m }
        };
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Bienvenido a MiConvertidorDeMonedas");
            Console.Write("Ingrese la cantidad a convertir: ");
            string amountInput = Console.ReadLine();
            decimal amount;
            while (!decimal.TryParse(amountInput, out amount))
            {
                Console.Write("Cantidad inválida. Intente de nuevo: ");
                amountInput = Console.ReadLine();
            }

            Console.Write("Ingrese la moneda de origen (ej. USD): ");
            string fromCurrency = Console.ReadLine().ToUpper();
            Console.Write("Ingrese la moneda de destino (ej. EUR): ");
            string toCurrency = Console.ReadLine().ToUpper();

            try
            {
                string log;
                decimal result = ConvertidorDeMonedas.MiConvertidorDeMonedas(amount, fromCurrency, toCurrency, exchangeRates, out log);
                Console.WriteLine($"\nResultado: {result}");
                Console.WriteLine(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.Write("¿Desea realizar otra conversión? (S/N): ");
            string respuesta = Console.ReadLine().Trim().ToUpper();
            continuar = (respuesta == "S");
            Console.WriteLine();
        }
    Console.WriteLine("¡Gracias por usar MiConvertidorDeMonedas!");
    Console.WriteLine("Goodbye");
    }
}
