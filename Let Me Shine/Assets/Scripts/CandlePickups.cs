using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePickups : MonoBehaviour
{
    GameManager gameManager;

    void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    /* 
    
    Candle Pickup method 

    TODO: 
    Increase length of the player here.
    Add pickup particle effect.
    Add pickup sound effect.

    */
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.candleLength++;
            Debug.Log("Candle's length is now: " + gameManager.candleLength);
            Destroy(gameObject);
        }
    }
}
