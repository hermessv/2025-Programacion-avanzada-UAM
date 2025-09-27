using System;
using System.Collections.Generic;

public class ConvertidorDeMonedas
{
    public static decimal MiConvertidorDeMonedas(
        decimal amount,
        string fromCurrency,
        string toCurrency,
        Dictionary<string, decimal> exchangeRates)
    {
        if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
            throw new ArgumentException("Moneda no soportada.");

        decimal amountInBase = amount / exchangeRates[fromCurrency];
        decimal convertedAmount = amountInBase * exchangeRates[toCurrency];
        return convertedAmount;
    }
}
