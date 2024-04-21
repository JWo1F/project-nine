using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private bool flipped = false;
    [SerializeField] private float jumpForce = 6f;

    private float moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var moveInput = Input.GetAxisRaw("Horizontal");
        var moveAmount = moveInput * moveSpeed * Time.deltaTime;

        if (moveInput != 0)
        {
            flipped = moveInput < 0;
        }

        transform.Translate(new Vector3(moveAmount, 0, 0));
        _renderer.flipX = flipped;

        var playerJump = Input.GetKeyDown(KeyCode.UpArrow);

        if (playerJump)
        {
            var hits = Physics2D.RaycastAll(transform.position, Vector2.down, 0.7f);
            var hasGround = hits.Any(hit2D => hit2D.collider.gameObject.name != "Player");
            if (hasGround)
            {
                _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        var nextState = CalculateState(moveAmount != 0, _rigidbody2D.velocity.y);
        if (_animator.GetInteger("State") != nextState)
        {
            _animator.SetInteger("State", nextState);
        }
    }

    private int CalculateState(bool move, float y)
    {
        switch (y)
        {
            case > 0:
                return 2;
            case < 0:
                return 3;
        }

        if (move) return 1;

        return 0;
    }
}
