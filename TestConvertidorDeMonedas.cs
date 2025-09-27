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
            { "JPY", 150.0m }
        };

        // Test 1: USD to EUR
        decimal result1 = ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "USD", "EUR", exchangeRates);
        Console.WriteLine($"100 USD to EUR: {result1} (Expected: 95)");

        // Test 2: EUR to MXN
        decimal result2 = ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "EUR", "MXN", exchangeRates);
        Console.WriteLine($"100 EUR to MXN: {result2} (Expected: 1789.47)");

        // Test 3: MXN to JPY
        decimal result3 = ConvertidorDeMonedas.MiConvertidorDeMonedas(1000, "MXN", "JPY", exchangeRates);
        Console.WriteLine($"1000 MXN to JPY: {result3} (Expected: 8823.53)");

        // Test 4: JPY to USD
        decimal result4 = ConvertidorDeMonedas.MiConvertidorDeMonedas(3000, "JPY", "USD", exchangeRates);
        Console.WriteLine($"3000 JPY to USD: {result4} (Expected: 20)");

        // Test 5: Invalid currency
        try
        {
            ConvertidorDeMonedas.MiConvertidorDeMonedas(100, "ABC", "USD", exchangeRates);
            Console.WriteLine("Test failed: Exception not thrown for invalid currency.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Test passed: Exception thrown for invalid currency.");
        }
    }
}
