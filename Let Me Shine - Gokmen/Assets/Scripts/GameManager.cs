using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float candleScore;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    public void Start() 
    {

    }

    void Update()
    {
        candleScore = PlayerManager.instance.GetScore();
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
        gives stars to the play according to it's final length ✓
        TODO: Display the stars on the screen after each level
        */

        if (candleScore < 3)
        {
            Debug.Log("loser lol | score : " + candleScore);
        }
        else if (candleScore > 3 && candleScore <= 5)
        {
            Debug.Log("1 stars | score: " + candleScore);
        }
        else if (candleScore > 5 && candleScore <= 7)
        {
            Debug.Log("2 stars | score: " + candleScore);
        }
        else if (candleScore > 7 && candleScore <= 10)
        {
            Debug.Log("3 stars | score: " + candleScore);
        }
        else if (candleScore > 10 && candleScore <= 12)
        {
            Debug.Log("4 stars | score: " + candleScore);
        }
        else if (candleScore > 12 && candleScore <= 15)
        {
            Debug.Log("5 stars | score: " + candleScore);
        }
        else { Debug.Log("god gamer | score: " + candleScore);}

        SceneManager.LoadScene(nextLevel);
    }

    public void OnLevelFailed() // Loads the current scene back on collision with an obstacle.
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
