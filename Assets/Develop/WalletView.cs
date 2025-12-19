using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WalletView : MonoBehaviour
{
    private Wallet _wallet;

    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private Image _coins;
    [SerializeField] private Image _diamonds;
    [SerializeField] private Image _energy;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        gameObject.SetActive(true);

        _wallet.Changed += OnChanged;

        OnChanged();
    }

    private void OnChanged()
    {
        string text = string.Empty;

        foreach (Currency currency in _wallet.Currencies)
        {
            text += $": {currency.Amount}\n";
        }

        _currencyText.text = text;
    }
}
