using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 30f;
    public float jump = 1f;
    private bool isJumping = false;
    private float moveHorizontal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of the frame rate
    void FixedUpdate()
    {
        if (moveHorizontal != 0f)
        {
            //Vector3 currentPosition = transform.position;
            //Vector3 newPosition = currentPosition + Vector3.right * moveHorizontal * Time.fixedDeltaTime * speed;
            rb.AddForce(Vector2.right * moveHorizontal * speed);
        }
        if (isJumping)
        {
            //Vector3 newPosition = transform.position;
            //newPosition += Vector3.up * moveVertical * Time.fixedDeltaTime * speed;
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

}
