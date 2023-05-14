using UnityEngine;
using UnityEngine.UI;

public class highest_score : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text += PlayerPrefs.GetInt("score").ToString();
    }
}
