using UnityEngine;

namespace Wallet
{
    public abstract class WalletListener: MonoBehaviour
    {
        protected void OnEnable()
        {
            GameState.CoinsChanged += DisplayAmount;
        }

        protected abstract void DisplayAmount();
        
        protected void OnDestroy()
        {
            GameState.CoinsChanged -= DisplayAmount;
        }
    }
}