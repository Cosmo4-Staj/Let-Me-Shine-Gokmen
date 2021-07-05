using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        
    }

    // General collision method TODO: particles, sound effects
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Pickup":
                AddLength();
                break;
            case "Finish":
                gameManager.OnLevelCompleted();
                break;
            case "Obstacle":
                gameManager.OnLevelFailed();
                break;
            case "String":
                CutCandle();
                break;
        }
    }

    private void AddLength()
    {
        Debug.Log("picked up a candle part, length increased");
    }

    private void CutCandle()
    {
        Debug.Log("you hit to a string and got cut");
    }
}
