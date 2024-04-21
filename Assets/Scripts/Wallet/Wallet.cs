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
        [SerializeField] private int _coins;
        [SerializeField] private int _lifes = 3;

        public int Coins => _coins;
        public int Lifes => _lifes;

        private void OnEnable()
        {
            Collectable.ItemCollected += Collect;
        }

        public void Damage(int damage)
        {
            _lifes -= damage;
            CoinsChanged?.Invoke();
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
                    break;
                case Collectable.Type.Life:
                    _lifes -= 1;
                    break;
            }
            
            CoinsChanged?.Invoke();
        }
        
        private void OnDisable()
        {
            Collectable.ItemCollected -= Collect;
        }
    }
}

