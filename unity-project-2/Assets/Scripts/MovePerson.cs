using UnityEngine;

public class MovePerson : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform respawn;

    [Header("Movement Settings")]
    public float speed = 30f;
    public float jump = 7f;
    private bool isJumping = false;
    private bool jumpRequested = false;
    private float moveHorizontal;

    [Header("Animator Settings")]
    private Animator animator;

    [Header("Facing Direction Settings")]
    private bool facingRight = true;

    [Header("Ground Check Settings")]
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform position;
    private bool isGrounded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (moveHorizontal != 0f)
        {
            rb.AddForce(Vector2.right * moveHorizontal * speed);
            //rb.linearVelocity = new Vector2(moveHorizontal * speed, 0);
        }
        AnimationRun();
        if (facingRight && moveHorizontal < 0)
        {
            Flip();
        }
        else if (!facingRight && moveHorizontal > 0)
        {
            Flip();
        }
        isGrounded = Physics2D.OverlapCircle(position.position, 0.1f, groundLayer);
        if (jumpRequested && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isJumping = true;
            jumpRequested = false;
        }
        else
        {
            isJumping = false;
        }
        AnimationJump();
    }

    void Flip()
    {
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        facingRight = !facingRight;
    }
    void AnimationRun()
    {
        if (moveHorizontal != 0)
        {
            animator.SetBool("ToRun", true);
        }
        else
        {
            animator.SetBool("ToRun", false);
        }
    }
    void AnimationJump()
    {
        if (isJumping)
        {
            animator.SetTrigger("ToJump");
        }
        else
        {
            animator.SetTrigger("ToIdle");
        }
    }
}