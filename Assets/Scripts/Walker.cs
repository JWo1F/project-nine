using UnityEngine;

public class Walker: MonoBehaviour
{
        [SerializeField] private bool leftWalk;
        [SerializeField] private float speed;

        private void Update()
        {
                var vectorWalk = leftWalk ? Vector2.left : Vector2.right;
                RaycastHit2D[] hits = new RaycastHit2D[10];
                var count = Physics2D.RaycastNonAlloc(transform.position, vectorWalk, hits, 0.5f);
                for (var i = 0; i < count; i++)
                {
                        var hit = hits[i];
                        if (hit.collider.gameObject == gameObject) continue;
                        leftWalk = !leftWalk;
                }
                transform.Translate(vectorWalk * (speed * Time.deltaTime));
        }
}