using TMPro;
using UnityEngine;

namespace Wallet
{
    public class CoinText : WalletListener
    {
        [SerializeField] protected Collectable.Type type = Collectable.Type.Coin;
        [SerializeField] private string prefix;

        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        protected override void DisplayAmount()
        {
            var count = type == Collectable.Type.Coin ? GameState.CoinsCount : GameState.LivesCount;
            _text.text = prefix + count;
        }
    }
}
