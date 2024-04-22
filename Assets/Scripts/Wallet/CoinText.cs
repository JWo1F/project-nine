using TMPro;
using UnityEngine;

namespace Wallet
{
    public class CoinText : WalletListener
    {
        [SerializeField] protected Collectable.Type type = Collectable.Type.Coin;

        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        protected override void DisplayAmount()
        {
            _text.text = type == Collectable.Type.Coin ? wallet.Coins.ToString() : wallet.Lives.ToString();
        }
    }
}
