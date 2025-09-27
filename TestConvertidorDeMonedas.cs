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
            // Direct rate example
            { "USD/GBP", 0.8m },
            // Inverse rate example (no direct USD/CHF, but CHF/USD exists)
            { "CHF/USD", 1.1m }
        };
        // Test 6: Direct rate USD to GBP
        string log6;
        decimal result6 = ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "USD", "GBP", exchangeRates, out log6);
        Console.WriteLine($"100 USD to GBP (direct rate): {result6} (Expected: 80)");
        Console.WriteLine(log6);

        // Test 7: Inverse rate USD to CHF (only CHF/USD exists)
        string log7;
        decimal result7 = ConvertidorDeMonedas.MiConvertidorDeMonedas(110, "USD", "CHF", exchangeRates, out log7);
        Console.WriteLine($"110 USD to CHF (inverse rate): {result7} (Expected: 100)");
        Console.WriteLine(log7);

        // Test 8: Unsupported currency
        try
        {
            string log8;
            ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "USD", "ABC", exchangeRates, out log8);
            Console.WriteLine("Test failed: Exception not thrown for unsupported currency.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Test passed: Exception thrown for unsupported currency.");
        }

        // Test 1: USD to EUR
        string log1;
        decimal result1 = ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "USD", "EUR", exchangeRates, out log1);
        Console.WriteLine($"100 USD to EUR: {result1} (Expected: 95)");
        Console.WriteLine(log1);

        // Test 2: EUR to MXN
        string log2;
        decimal result2 = ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "EUR", "MXN", exchangeRates, out log2);
        Console.WriteLine($"100 EUR to MXN: {result2} (Expected: 1789.47)");
        Console.WriteLine(log2);

        // Test 3: MXN to JPY
        string log3;
        decimal result3 = ConvertidorDeMonedas.MiConvertidorDeMonedas(1000, "MXN", "JPY", exchangeRates, out log3);
        Console.WriteLine($"1000 MXN to JPY: {result3} (Expected: 8823.53)");
        Console.WriteLine(log3);

        // Test 4: JPY to USD
        string log4;
        decimal result4 = ConvertidorDeMonedas.MiConvertidorDeMonedas(3000, "JPY", "USD", exchangeRates, out log4);
        Console.WriteLine($"3000 JPY to USD: {result4} (Expected: 20)");
        Console.WriteLine(log4);

        // Test 5: Invalid currency
        try
        {
            string log5;
            ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "ABC", "USD", exchangeRates, out log5);
            Console.WriteLine("Test failed: Exception not thrown for invalid currency.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Test passed: Exception thrown for invalid currency.");
        }
    }
}
