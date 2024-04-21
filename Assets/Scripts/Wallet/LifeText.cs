using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
    public class LifeText: WalletListener
    {
        [SerializeField] private GameObject[] lifes;

        protected override void DisplayAmount()
        {
            var current = wallet.Lifes;
            for (var i = 0; i < lifes.Length; i++)
                lifes[i].SetActive(current >= i + 1);
        }
    }
}