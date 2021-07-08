using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int level;
    public GameObject finishLevelScreen;
    public GameObject starCountText;
    public float candleScore;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
    public int finalScore;
    public List<GameObject> levelList = new List<GameObject>();
    PlayerManager playerManager;


    public void Start() 
    {
        playerManager = FindObjectOfType<PlayerManager>();
        finishLevelScreen.SetActive(false);
        Instantiate(levelList[level], transform.position, Quaternion.identity);
        Debug.Log(level);
        
    }

    void Update()
    {
        candleScore = PlayerManager.instance.GetScore();
        starCountText.GetComponent<TextMeshProUGUI>().SetText(finalScore.ToString());
        TooSmallToLive();

    }

    public void OnLevelStarted()
    {
        
        // TODO: Load UIs and Background music
    }

    public void OnLevelEnded() // Game Over?
    {
        isGameEnded=true;
        Application.Quit();
    }

    public void OnLevelCompleted() // Loads the next level
    {
        finishLevelScreen.gameObject.SetActive(true);
        playerManager.enabled=false;
        Time.timeScale=0;
        level=1;

        /* 
        gives stars to the play according to it's final length ✓
        TODO: Display the stars on the screen after each level
        */

        if (candleScore < 5)
        {
            finalScore=0;
            Debug.Log("loser lol | score : " + candleScore);
        }
        else if (candleScore > 5 && candleScore <= 7)
        {
            finalScore=1;
            Debug.Log("1 stars | score: " + candleScore);
        }
        else if (candleScore > 7 && candleScore <= 10)
        {
            finalScore=2;
            Debug.Log("2 stars | score: " + candleScore);
        }
        else if (candleScore > 10 && candleScore <= 13)
        {
            finalScore=3;
            Debug.Log("3 stars | score: " + candleScore);
        }
        else if (candleScore > 13 && candleScore <= 15)
        {
            finalScore=4;
            Debug.Log("4 stars | score: " + candleScore);
        }
        else if (candleScore > 15 && candleScore <= 20)
        {
            finalScore=5;
            Debug.Log("5 stars | score: " + candleScore);
        }
        else 
        {
            finalScore=5;
            Debug.Log("god gamer | score: " + candleScore);
        }

        
    }

    public void OnLevelFailed() // Loads the current scene back on collision with an obstacle.
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
        Time.timeScale=1;
    }

    // loads next level upon button tap
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale=1;
    }

    private void TooSmallToLive()
    {
        if (candleScore <= 1)
        {
            OnLevelFailed();
        }
    }
}
