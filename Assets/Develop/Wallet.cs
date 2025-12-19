using System;
using System.Collections.Generic;

public class Wallet
{
    public Action Changed;

    private readonly List<Currency> _currencies;

    public Wallet()
    {
        _currencies = new List<Currency>()
        {
            new Currency(CurrencyType.Coins),
            new Currency(CurrencyType.Diamonds),
            new Currency(CurrencyType.Energy),
        };
    }

    public List<Currency> Currencies => _currencies;

    public void Add(CurrencyType type, int value)
    {
        foreach (Currency currency in _currencies)
            if (currency.Type == type)
            {
                currency.Add(value);
                Changed?.Invoke();
            }
    }

    public void Spend(CurrencyType type, int value)
    {
        foreach (Currency currency in _currencies)
            if (currency.Type == type)
            {
                currency.Spend(value);
                Changed?.Invoke();
            }
    }
}
