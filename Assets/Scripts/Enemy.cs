using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy: MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private bool safeTop;
    [SerializeField] private int bounceForce = 7;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherWallet = other.gameObject.GetComponent<Wallet.Wallet>();
        if (otherWallet == null) return;
        if (safeTop && other.transform.position.y > transform.position.y) return;
        
        var otherRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
        var vector = (other.gameObject.transform.position - transform.position).normalized * bounceForce;
        
        otherWallet.Damage(damage);
        Debug.Log("Damage!");
        otherRigidBody.AddForce(vector, ForceMode2D.Impulse);
    }
}
