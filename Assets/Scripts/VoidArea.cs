using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class VoidArea : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        var color = Color.red;
        color.a = 0.5f;
        Gizmos.color = color;
        var position = transform.position;
        Gizmos.DrawCube(new Vector2(position.x, position.y) + boxCollider.offset, boxCollider.size);
    }
}
