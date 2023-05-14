using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int nbCoins;
    public int nbPoints;

    public int combo;

    public Text nbCoinsText;
    public Text nbPointsText;

    public static inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        nbCoins = 0;
        nbPoints = 0;
        setCoinsText();
        setPointsText();
    }

    public void setCoinsText()
    {
        nbCoinsText.text = nbCoins.ToString();
    }
    
    public void setPointsText()
    {
        nbPointsText.text = nbPoints.ToString();
    }
}
