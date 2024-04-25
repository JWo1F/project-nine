using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class VoidArea : MonoBehaviour
{
    [SerializeField] private Color color = Color.red;

    private void OnDrawGizmos()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        Gizmos.color = color;
        var position = transform.position;
        Gizmos.DrawCube(new Vector2(position.x, position.y) + boxCollider.offset, boxCollider.size);
    }
}
