using System;
using System.Collections.Generic;

public class ConvertidorDeMonedas
{
    public static decimal MiConvertidorDeMonedas(
        decimal amount,
        string fromCurrency,
        string toCurrency,
        Dictionary<string, decimal> exchangeRates,
        out string log)
    {
        if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
            throw new ArgumentException("Moneda no soportada.");

        decimal amountInBase = amount / exchangeRates[fromCurrency];
        decimal convertedAmount = amountInBase * exchangeRates[toCurrency];

        string fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        log = $"En la fecha {fecha} se soilcitó la conversión de {amount} unidades de la moneda {fromCurrency} a {toCurrency} dando como resultado {convertedAmount}.";

        return convertedAmount;
    }
}
