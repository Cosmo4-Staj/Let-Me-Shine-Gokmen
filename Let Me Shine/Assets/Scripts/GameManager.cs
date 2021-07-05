using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float candleLength = 5f;
    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnLevelStarted()
    {
        // TODO: Load UIs and Background music
    }

    public void OnLevelEnded() // Game Over?
    {
        Application.Quit();
    }

    public void OnLevelCompleted() // Loads the next level
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel+1;

        // if current level is the last level, loads the first level.
        if(nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        
        /* 
        gives stars to the play according to it's final length
        TODO: Display the stars on the screen after each level
        */
        if (candleLength <= 5)
        {
            Debug.Log("loser lol (give 1 star)");
        }
        else if (candleLength > 5 && candleLength <= 10)
        {
            Debug.Log("give 2 stars");
        }
        else if (candleLength > 10 && candleLength <= 15)
        {
            Debug.Log("give 3 stars");
        }
        else if (candleLength > 15 && candleLength <= 20)
        {
            Debug.Log("give 3 stars");
        }
        else if (candleLength > 20 && candleLength <= 25)
        {
            Debug.Log("give 4 stars");
        }
        else if (candleLength > 25 && candleLength <= 50)
        {
            Debug.Log("give 5 stars");
        }
        else { Debug.Log("yes");}

        SceneManager.LoadScene(nextLevel);
    }

    public void OnLevelFailed() // Loads the current scene back on collision with an obstacle.
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
