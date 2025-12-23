using UnityEngine;

public class WalletExample : MonoBehaviour
{
    private Wallet _wallet;

    [SerializeField] private WalletView _walletViewPrefab;
    [SerializeField] private Canvas _canvas;

    private void Awake()
    {
        WalletView _walletView = Instantiate(_walletViewPrefab, _canvas.transform);

        _wallet = new Wallet(
            new Currency(CurrencyType.Coins),
            new Currency(CurrencyType.Diamonds),
            new Currency(CurrencyType.Energy)
            );

        _walletView.Initialize(_wallet);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _wallet.Add(CurrencyType.Coins, 1);

        if (Input.GetKeyDown(KeyCode.A))
            _wallet.Spend(CurrencyType.Coins, 1);

        if (Input.GetKeyDown(KeyCode.W))
            _wallet.Add(CurrencyType.Diamonds, 1);

        if (Input.GetKeyDown(KeyCode.S))
            _wallet.Spend(CurrencyType.Diamonds, 1);

        if (Input.GetKeyDown(KeyCode.E))
            _wallet.Add(CurrencyType.Energy, 1);

        if (Input.GetKeyDown(KeyCode.D))
            _wallet.Spend(CurrencyType.Energy, 1);
    }
}
