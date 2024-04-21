using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wallet
{
    public class CoinText : MonoBehaviour
    {
        [SerializeField] private Wallet wallet;

        private TextMeshProUGUI _text;
        
        private void OnEnable()
        {
            _text = GetComponent<TextMeshProUGUI>();
            wallet.CoinsChanged += DisplayAmount;
        }

        private void DisplayAmount()
        {
            _text.text = wallet.Coins.ToString();
        }
        
        private void OnDestroy()
        {
            wallet.CoinsChanged -= DisplayAmount;
        }
    }
}
