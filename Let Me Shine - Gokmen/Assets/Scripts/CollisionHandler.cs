using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    PlayerManager playerManager;
    public float amountToMeltOnBridge = 10f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }


    void Update()
    {
        
    }

    // General collision method TODO: particles, sound effects
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                gameManager.OnLevelCompleted();
                break;
            case "Obstacle":
                gameManager.OnLevelFailed();
                break;
            case "Bridge":
                playerManager.meltBy += amountToMeltOnBridge;
                break;
        }
    }

    // Puts the normal melt speed back.
    void OnCollisionExit(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Bridge":
                playerManager.meltBy -= amountToMeltOnBridge;
                break;
        }
    }

    // Increase candle length on pickup and speed up the melting while on bridge.
    void OnTriggerEnter(Collider other) 
    {
        switch (other.gameObject.tag)
        {
            case "Pickup":
                playerManager.AddLength();
                Destroy(other.gameObject);
                break;
            case "String":
                playerManager.CutLength();
                break;
        }
    }
}
