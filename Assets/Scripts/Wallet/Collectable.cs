using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Wallet
{
    [RequireComponent(typeof(Collider2D))]
    public class Collectable: MonoBehaviour
    {
        public enum Type
        {
            Coin,
            Life,
        }

        [SerializeField] private Type type = Type.Coin;
        [SerializeField] private int count = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var wallet = other.gameObject.GetComponent<Wallet>();
            if (wallet == null) return;

            wallet.Collect(type, count);
            Destroy(gameObject);
        }
    }
}
