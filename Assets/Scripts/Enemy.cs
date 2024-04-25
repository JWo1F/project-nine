using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy: MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private bool safeTop;
    [SerializeField] private int bounceForce = 7;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Player") return;
        if (safeTop && other.transform.position.y > transform.position.y) return;
        
        var otherRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
        var vector = (other.transform.position - transform.position).normalized * bounceForce;

        GameState.LivesCount -= damage;
        otherRigidBody.AddForce(vector, ForceMode2D.Impulse);
    }
}
