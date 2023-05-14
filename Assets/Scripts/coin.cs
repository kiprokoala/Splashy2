using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        inventory.instance.nbCoins++;
        inventory.instance.setCoinsText();
        Destroy(gameObject);
    }
}
