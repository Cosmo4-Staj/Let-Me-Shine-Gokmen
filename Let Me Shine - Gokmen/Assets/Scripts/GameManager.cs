using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public float candleScore = 10f;
    public float amountOfScoreDecreased = 0.5f;

    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    void Update()
    {
        StartCoroutine(CalculateScore());
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

        if (candleScore < 10)
        {
            Debug.Log("loser lol | score : " + candleScore);
        }
        else if (candleScore > 10 && candleScore <= 20)
        {
            Debug.Log("1 stars | score: " + candleScore);
        }
        else if (candleScore > 20 && candleScore <= 30)
        {
            Debug.Log("2 stars | score: " + candleScore);
        }
        else if (candleScore > 30 && candleScore <= 50)
        {
            Debug.Log("3 stars | score: " + candleScore);
        }
        else if (candleScore > 50 && candleScore <= 75)
        {
            Debug.Log("4 stars | score: " + candleScore);
        }
        else if (candleScore > 75 && candleScore <= 100)
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

    IEnumerator CalculateScore()
    {
        candleScore -= amountOfScoreDecreased * Time.deltaTime;
        yield return null;

    }
}
