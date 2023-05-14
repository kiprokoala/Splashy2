using UnityEngine;
using UnityEngine.SceneManagement;

public class deathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetInt("score") < inventory.instance.nbPoints) 
        {
            PlayerPrefs.SetInt("score", inventory.instance.nbPoints);
        }
        SceneManager.LoadScene(0);
    }
}
