using TMPro;
using UnityEngine;

namespace Wallet
{
    public abstract class WalletListener: MonoBehaviour
    {
        [SerializeField] protected Wallet wallet;

        protected void OnEnable()
        {
            wallet.CoinsChanged += DisplayAmount;
        }

        protected abstract void DisplayAmount();
        
        protected void OnDestroy()
        {
            wallet.CoinsChanged -= DisplayAmount;
        }
    }
}