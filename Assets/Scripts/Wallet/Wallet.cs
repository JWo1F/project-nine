using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wallet
{
    public class Wallet : MonoBehaviour
    {
        public event UnityAction CoinsChanged;
        private int _coins = 0;

        public int Coins => _coins;

        private void OnEnable()
        {
            Collectable.ItemCollected += Collect;
        }

        private void Start()
        {
            CoinsChanged?.Invoke();
        }

        private void Collect(Collectable.Type type)
        {
            switch (type)
            {
                case Collectable.Type.Coin:
                    _coins += 1;
                    CoinsChanged?.Invoke();
                    break;
                case Collectable.Type.Life:
                    break;
            }
        }
        
        private void OnDisable()
        {
            Collectable.ItemCollected -= Collect;
        }
    }
}

