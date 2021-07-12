using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    PlayerManager playerManager;
    AudioSource audioSource;
    public float amountToMeltOnBridge = 10f;
    public float levelLoadDelay = 1f;
    [SerializeField] AudioClip finish;
    [SerializeField] AudioClip pickup;
    [SerializeField] AudioClip cut;
    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] ParticleSystem startParticles;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        audioSource = GetComponent<AudioSource>();
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
                playerManager.enabled=false;
                audioSource.PlayOneShot(finish);
                finishParticles.Play();
                Invoke("Finish", levelLoadDelay);
                break;
            case "Obstacle":
                startParticles.Play();
                Destroy(other.gameObject);
                break;
            case "Bridge":
                playerManager.meltBy += amountToMeltOnBridge;
                break;
            
        }
    }

    // Increase candle length on pickup and speed up the melting while on bridge.
    void OnTriggerEnter(Collider other) 
    {
        switch (other.gameObject.tag)
        {
            case "Pickup":
                audioSource.PlayOneShot(pickup, 0.5f);
                playerManager.AddLength();
                Destroy(other.gameObject);
                break;
            case "String":
                audioSource.PlayOneShot(cut, 2f);
                playerManager.CutLength();

                if (playerManager.willDie==false)
                {
                    playerManager.SpawnCandlePart();
                }
                break;
            case "Bridge":
                playerManager.meltBy += amountToMeltOnBridge;
                break;
        }
    }

    void OnCollisionExit(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Bridge":
                playerManager.meltBy -= amountToMeltOnBridge;
                break;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        switch (other.gameObject.tag)
        {
            case "Bridge":
                playerManager.meltBy -= amountToMeltOnBridge;
                break;
        }
    }

    void Finish()
    {
        gameManager.OnLevelCompleted();
    }
}
