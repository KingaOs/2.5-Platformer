using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player_Draft player = other.GetComponent<Player_Draft>();

            if (player != null)
                player.AddCoins();

            Destroy(this.gameObject);
        }
    }


}
