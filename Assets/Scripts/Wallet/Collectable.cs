using System;
using UnityEngine;
using UnityEngine.Events;

namespace Wallet
{
    [RequireComponent(typeof(Collider2D))]
    public class Collectable: MonoBehaviour
    {
        public static event UnityAction<Type> ItemCollected;
        
        public enum Type
        {
            Coin,
            Life,
        }

        [SerializeField] private Type _type = Type.Coin;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var collector = other.gameObject.GetComponent<CoinCollector>();
            if (collector == null) return;
            
            ItemCollected?.Invoke(_type);
            Destroy(gameObject);
        }
    }
}
