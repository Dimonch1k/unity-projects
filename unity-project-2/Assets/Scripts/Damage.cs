using UnityEngine;
public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HeartSystem>().Hearts();
            other.transform.position = other.GetComponent<MovePerson>().respawn.position;
        }
    }
}
