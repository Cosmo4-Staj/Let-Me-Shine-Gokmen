using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePickups : MonoBehaviour
{
    GameManager gameManager;
    public bool scored = false;
    [SerializeField] GameObject playerParent;
    [SerializeField] float addCandle = 0.05f;
    [SerializeField] float amountOfScoreIncreased = 2f;

    void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    /* 
    
    Candle Pickup method 

    TODO: 
    Increase length of the player here. ✓
    Add pickup particle effect.
    Add pickup sound effect.

    */
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.candleScore += amountOfScoreIncreased;
            other.gameObject.transform.localScale += new Vector3(0, addCandle, 0);
            Destroy(gameObject);
        }
    }
}
