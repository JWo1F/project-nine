using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float maxSpeed = 10f;

    [Header("Jump Settings")]
    public float jumpForce = 10f;
    public float airJumpForce = 7f;
    public int maxJumps = 2;

    [Header("Ground Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D _rb;
    private SpriteRenderer _spr;
    private bool _isGrounded;
    private int _remainingJumps;
    private Animator _animator;
    private bool _prevLeft;
    
    private static readonly int State = Animator.StringToHash("State");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _remainingJumps = maxJumps;
        _prevLeft = _spr.flipX;
    }

    private void Update()
    {
        // Check for ground
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float currentSpeed = _rb.velocity.x;
        float targetSpeed = horizontalInput * moveSpeed;

        if (_isGrounded)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime * 0.5f);
        }

        // Limit max speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        _rb.velocity = new Vector2(currentSpeed, _rb.velocity.y);

        // Jumping
        if (_isGrounded)
        {
            _remainingJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _remainingJumps > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _remainingJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !_isGrounded && _remainingJumps > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, airJumpForce);
            _remainingJumps--;
        }

        var velocity = _rb.velocity;
        var nextState = CalculateState(velocity.x != 0, velocity.y);
        if (_animator.GetInteger(State) != nextState) _animator.SetInteger(State, nextState);

        if (velocity.x == 0) return;
        var nextLeft = velocity.x < 0;
        if (nextLeft != _prevLeft) _spr.flipX = !_spr.flipX;
        _prevLeft = nextLeft;
    }
    
    private static int CalculateState(bool move, float y)
    {
        if (y > 0.1 || y < -0.1) switch (y)
        {
            case > 0:
                return 2;
            case < 0:
                return 3;
        }

        if (move) return 1;

        return 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
