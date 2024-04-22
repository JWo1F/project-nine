using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class JumpKilled: MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D other)
        {
                if (other.gameObject.name != "Player") return;
                if (other.transform.position.y <= transform.position.y) return;

                Destroy(gameObject);
                var rgdb = other.gameObject.GetComponent<Rigidbody2D>();
                if (rgdb == null) return;
                rgdb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
}