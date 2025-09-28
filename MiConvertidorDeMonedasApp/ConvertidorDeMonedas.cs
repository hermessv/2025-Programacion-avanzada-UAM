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
        decimal convertedAmount = 0;
        bool found = false;

        // Direct rate by base
        if (exchangeRates.ContainsKey(fromCurrency) && exchangeRates.ContainsKey(toCurrency))
        {
            decimal amountInBase = amount / exchangeRates[fromCurrency];
            convertedAmount = amountInBase * exchangeRates[toCurrency];
            found = true;
        }
        // Direct rate as pair
        else if (exchangeRates.ContainsKey(fromCurrency + "/" + toCurrency))
        {
            convertedAmount = amount * exchangeRates[fromCurrency + "/" + toCurrency];
            found = true;
        }
        // Inverse rate as pair
        else if (exchangeRates.ContainsKey(toCurrency + "/" + fromCurrency))
        {
            convertedAmount = amount / exchangeRates[toCurrency + "/" + fromCurrency];
            found = true;
        }
        else
        {
            // Try to find an intermediate currency
            foreach (var intermediate in exchangeRates.Keys)
            {
                // Only consider valid currency codes (not pairs)
                if (intermediate.Length != 3 || intermediate == fromCurrency || intermediate == toCurrency)
                    continue;

                try
                {
                    string dummyLog;
                    decimal firstLeg = MiConvertidorDeMonedas(amount, fromCurrency, intermediate, exchangeRates, out dummyLog);
                    decimal secondLeg = MiConvertidorDeMonedas(firstLeg, intermediate, toCurrency, exchangeRates, out dummyLog);
                    convertedAmount = secondLeg;
                    found = true;
                    break;
                }
                catch { }
            }
        }

        if (!found)
        {
            throw new ArgumentException("Moneda no soportada o tasa de cambio no disponible.");
        }

        convertedAmount = Math.Round(convertedAmount, 2);
        string fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        log = $"En la fecha {fecha} se soilcitó la conversión de {amount} unidades de la moneda {fromCurrency} a {toCurrency} dando como resultado {convertedAmount}.";

        return convertedAmount;
    }
}
