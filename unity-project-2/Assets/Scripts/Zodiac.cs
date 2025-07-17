using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zodiac : MonoBehaviour
{
    [SerializeField] 
    private Text zodiacText;
    [SerializeField]
    TextAsset zodiacData;

    private Dictionary<string, string> zodiacDictionary = new Dictionary<string, string>();
    void Start()
    {
        string text = zodiacData.text;
        string[] zodiac = text.Split('\n');
        foreach(string line in zodiac)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split(':');
            zodiacDictionary.Add(parts[0], parts[1]);
        }
    }

    public void ShowText(string key)
    {
        zodiacText.text = zodiacDictionary.ContainsKey(key) ? zodiacDictionary[key] : "Zodiac not found.";
    }
}
