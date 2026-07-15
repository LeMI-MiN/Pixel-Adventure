using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody2D
    public Rigidbody2D rb;
    private float moveInput;

    // Moving Speed
    [SerializeField]
    private float moveSpeed = 2f;

    // Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isGround;

    // Wall Check
    [SerializeField] private Transform wallCheckL;
    [SerializeField] private Transform wallCheckR;
    [SerializeField] private LayerMask wallLayer;

    // Wall Direction
    private int wallDirection;

    // Wall Jump
    [SerializeField] private float wallJumpXForce = 5f;
    [SerializeField] private float wallJumpYForce = 8f;
    private bool isWall;
    private bool canWallJump = true;    // Anti-Moon Jump

    // Wall Slide
    [SerializeField] private float wallSlideSpeed = 2f;
    public bool isWallSliding;

    // Jump
    [SerializeField] private float jumpForce = 3f;

    // Double Jump
    private bool canDoubleJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Ground Check
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Wall Check
        bool wallL = Physics2D.OverlapCircle(wallCheckL.position, 0.1f, wallLayer);
        bool wallR = Physics2D.OverlapCircle(wallCheckR.position, 0.1f, wallLayer);

        isWall = wallL || wallR;

        // WallDirection
        if (wallL)
        {
            wallDirection = -1;
        }
        else if (wallR)
        {
            wallDirection = 1;
        }

        // Anti-Moon Jump
        if (!isWall)
        {
            canWallJump = true;
        }

        // Wall Slide
        if ((wallL && moveInput < 0) || (wallR && moveInput > 0))
        {
            if (!isGround)
            {
                isWallSliding = true;
            }
            else
            {
                isWallSliding = false;
            }
        }
        else
        {
            isWallSliding = false;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Wall Jump(Anti-Moon Jump)
            if (isWall && !isGround && canWallJump)
            {
                rb.linearVelocity = new Vector2(-wallDirection * wallJumpXForce, wallJumpYForce);
                canWallJump = false;

                return;
            }

            // Jump
            if (isGround)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }

            // Double Jump
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                canDoubleJump = false;
            }
        }

        // Filp
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Double Jump
        if (isGround)
        {
            canDoubleJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (isWallSliding && rb.linearVelocity.y < -wallSlideSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
        }
    }
}