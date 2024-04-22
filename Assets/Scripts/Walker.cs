using System;
using UnityEngine;
using Wallet;

[RequireComponent(typeof(SpriteRenderer))]
public class Walker: MonoBehaviour
{
        [SerializeField] private bool leftWalk;
        [SerializeField] private float speed;

        private SpriteRenderer _renderer;

        private void Start()
        {
                _renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
                var vectorWalk = leftWalk ? Vector2.left : Vector2.right;
                var hits = new RaycastHit2D[2];
                var count = Physics2D.RaycastNonAlloc(transform.position, vectorWalk, hits, 1f);
                var positionChanged = false;
                for (var i = 0; i < count; i++)
                {
                        var obj = hits[i].collider.gameObject;
                        if (obj == gameObject || obj.name == "Player") continue;
                        if (obj.GetComponent<Collectable>()) continue;
                        leftWalk = !leftWalk;
                        positionChanged = true;
                        break;
                }
                transform.Translate(vectorWalk * (speed * Time.deltaTime));

                if (positionChanged)
                {
                        _renderer.flipX = !_renderer.flipX;
                }
        }
}