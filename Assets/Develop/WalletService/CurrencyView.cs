using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountText;

    private Currency _currency;

    public void Initialize(Currency currency)
    {
        _currency = currency;

        _currency.AmountChanged += OnAmountChanged;
    }

    private void OnDestroy()
    {
        if (_currency != null)
            _currency.AmountChanged -= OnAmountChanged;
    }

    private void OnAmountChanged()
    {
        _amountText.text = ": " + _currency.Amount.ToString();
    }
}
