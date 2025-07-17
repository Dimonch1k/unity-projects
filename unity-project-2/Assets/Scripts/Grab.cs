using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private int count = 0;
    [SerializeField]
    private Text text;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grab"))
        {
            count++;
            text.text = count.ToString();
            Destroy(other.gameObject);
        }
    }
}
