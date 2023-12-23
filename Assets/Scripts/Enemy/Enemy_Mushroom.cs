using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public float moveSpeed;
    public float idleTime;

    [Header("Collision info")]

    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    private float stateTimer;

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stateTimer = idleTime;
        anim.SetBool("Idle", true);
        anim.SetBool("Move", false);
    }

    void Update()
    {
        stateTimer -= Time.deltaTime;
        if(stateTimer < 0)
        {
            EnterMoveState();
        }

        if (IsWallDetected() || !IsGroundDetected())
        {
            EnterIdleState();
            Flip();
        }
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    public void EnterIdleState()
    {
        stateTimer = idleTime;
        anim.SetBool("Idle", true);
        anim.SetBool("Move", false);
    }
    public void EnterMoveState()
    {
        SetVelocity(moveSpeed * facingDir, rb.velocity.y);
        anim.SetBool("Idle", false);
        anim.SetBool("Move", true);
    }

    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if (x >= 0 && !facingRight)
            Flip();
        else if (x < 0 && facingRight)
            Flip();
    }

    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
}
