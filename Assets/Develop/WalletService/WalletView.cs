using UnityEngine;


public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _coinsPrefabs;
    [SerializeField] private CurrencyView _diamondsPrefabs;
    [SerializeField] private CurrencyView _energyPrefabs;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (Currency currency in _wallet.Currencies)
        {
            CurrencyView currentPrefab = GetPrefab(currency.Type);

            if (currentPrefab != null)
            {
                CurrencyView instance = Instantiate(currentPrefab, transform);
                instance.Initialize(currency);
            }
        }
    }

    private CurrencyView GetPrefab(CurrencyType type)
    {
        switch (type)
        {
            case CurrencyType.Coins:
                return  _coinsPrefabs;

            case CurrencyType.Diamonds:
                return _diamondsPrefabs;

            case CurrencyType.Energy:
                return _energyPrefabs;

            default:
                return null;
        }
    }
}
