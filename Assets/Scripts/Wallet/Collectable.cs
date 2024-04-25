using UnityEngine;

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
            if (other.gameObject.name != "Player") return;

            if (type == Type.Coin)
                GameState.CoinsCount += count;
            else if (type == Type.Life)
                GameState.LivesCount += count;

            Destroy(gameObject);
        }
    }
}
