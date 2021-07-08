using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePickups : MonoBehaviour
{
    GameManager gameManager;
    PlayerManager playerManager;
    public bool scored = false;
    [SerializeField] GameObject playerParent;
    [SerializeField] float addCandle = 0.05f;
    [SerializeField] float amountOfScoreIncreased = 2f;

    void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    
    /* 
    
    Candle Pickup method 

    TODO: 
    Add pickup particle effect.
    Add pickup sound effect.

    */
}
