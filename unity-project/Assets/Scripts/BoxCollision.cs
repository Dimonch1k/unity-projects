using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface") &&
            collision.gameObject != this.gameObject)
        {
            HandleGroundCollision(collision);
        }
    }

    void HandleGroundCollision(Collision2D collision)
    {
        Debug.Log("Box hit ground: " + collision.gameObject.name);
        rb.linearVelocity = Vector2.zero;

        // Optional: Make box stick to surface
        transform.SetParent(collision.transform);
    }
}