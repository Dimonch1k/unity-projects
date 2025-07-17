using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    int levelIndex;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MoveCircle>() != null || collider.GetComponent<MovePerson>() != null)
        {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
