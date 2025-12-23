using System.Collections.Generic;

public class Wallet
{
    private readonly List<Currency> _currencies;

    public Wallet(params Currency[] currencies)
    {
        _currencies = new List<Currency>();

        for (int i = 0; i < currencies.Length; i++)
        {
            Currency newCurrency = currencies[i];

            bool exists = false;

            foreach (Currency currency in _currencies)
            {
                if (currency.Type == newCurrency.Type)
                {
                    exists = true;
                    break;
                }
            }

            if (exists == false)
                _currencies.Add(newCurrency);
        }
    }

    public List<Currency> Currencies => _currencies;

    public void Add(CurrencyType type, int value)
    {
        Currency currency = GetCurrency(type);

        if (currency != null)
            currency.Add(value);
    }

    public void Spend(CurrencyType type, int value)
    {
        Currency currency = GetCurrency(type);

        if (currency != null)
            currency.Spend(value);
    }

    private Currency GetCurrency(CurrencyType type)
    {
        foreach (Currency currency in _currencies)
            if (currency.Type == type)
                return currency;

        return null;
    }
}
