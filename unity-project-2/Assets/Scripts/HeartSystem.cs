using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HeartSystem : MonoBehaviour
{
    public int hearts = 3;
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < heartImages.Length; i++)
        {
            if (i < hearts)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

    public void Hearts()
    {
        hearts--;
        if (hearts <= 0)
        {
            SceneManager.LoadScene("Scene_Menu");
        }
    }
}
