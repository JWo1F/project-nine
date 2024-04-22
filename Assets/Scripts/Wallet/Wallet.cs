using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Wallet
{
    public class Wallet : MonoBehaviour
    {
        public event UnityAction CoinsChanged;
        [SerializeField] private int coins;
        [SerializeField] private int lives = 3;

        public int Coins
        {
            get => coins;
            set
            {
                coins = value;
                CoinsChanged?.Invoke();
            }
        }

        public int Lives
        {
            get => lives;
            set
            {
                lives = value;
                CoinsChanged?.Invoke();
            }
        }

        private void Start()
        {
            CoinsChanged?.Invoke();
        }

        public void Collect(Collectable.Type type, int count)
        {
            switch (type)
            {
                case Collectable.Type.Coin:
                    coins += count;
                    break;
                case Collectable.Type.Life:
                    lives += count;
                    break;
            }
            
            CoinsChanged?.Invoke();
        }
    }
}

