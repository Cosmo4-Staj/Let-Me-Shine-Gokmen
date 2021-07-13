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
    public GameObject gameOverScreen;
    public GameObject inGameScreen;
    public GameObject starCountText;
    public GameObject scoreText;
    public GameObject scoreTextING;
    public GameObject levelTextING;
    public float candleScore;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
    public int finalScore;
    
    AudioSource audioSource;
    [SerializeField] AudioClip fail;
    [SerializeField] AudioClip background;
    
    public List<GameObject> levelList = new List<GameObject>();
    PlayerManager playerManager;
    [SerializeField] ParticleSystem finishParticles;

    void Awake() 
    {
        Application.targetFrameRate = 60;
    }

    public void Start() 
    {    
        OnLevelStarted();
        LoadLevel();
              
    }

    void Update()
    {
        candleScore = PlayerManager.instance.GetScore();
        starCountText.GetComponent<TextMeshProUGUI>().SetText(finalScore.ToString());
        scoreText.GetComponent<TextMeshProUGUI>().SetText(Mathf.RoundToInt(candleScore).ToString());
        levelTextING.GetComponent<TextMeshProUGUI>().SetText((level+1).ToString());
        scoreTextING.GetComponent<TextMeshProUGUI>().SetText(Mathf.RoundToInt(candleScore).ToString());
        TooSmallToLive();

    }

    public void OnLevelStarted()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        audioSource = GetComponent<AudioSource>();
        inGameScreen.SetActive(true);
        finishLevelScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void OnLevelEnded() // Game Over?
    {
        isGameEnded=true;
        Application.Quit();
    }

    public void OnLevelCompleted() // Loads the next level
    {
        inGameScreen.gameObject.SetActive(false);
        finishLevelScreen.gameObject.SetActive(true);
        Time.timeScale=0;

        if (candleScore < 1)
        {
            finalScore=0;
            Debug.Log("0 stars | score: " + candleScore);
        }
        else if (candleScore > 1 && candleScore <= 2)
        {
            finalScore=1;
            Debug.Log("1 stars | score: " + candleScore);
        }
        else if (candleScore > 2 && candleScore <= 4)
        {
            finalScore=2;
            Debug.Log("2 stars | score: " + candleScore);
        }
        else if (candleScore > 4 && candleScore <= 6)
        {
            finalScore=3;
            Debug.Log("3 stars | score: " + candleScore);
        }
        else if (candleScore > 6 && candleScore <= 7)
        {
            finalScore=4;
            Debug.Log("4 stars | score: " + candleScore);
        }
        else if (candleScore > 7 && candleScore <= 10)
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
        Time.timeScale=0;
        inGameScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
    }

    public void Retry() // Function of the retry button
    {
        SceneManager.LoadScene(1);
        Time.timeScale=1;
    }

    public void ReturnToMainMenu() // self-explanatory
    {
        SceneManager.LoadScene(0);
    }

    // loads next level upon button tap
    public void NextLevel()
    {
        level++;
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(1);
        Time.timeScale=1;
    }

    // Holds level values and loads them into the scene.
    public void LoadLevel()
    {
        level = PlayerPrefs.GetInt("Level", 0);

        if (level> levelList.Count -1 || level <0)
        {
            level = 0;
            PlayerPrefs.SetInt("Level", level);
        }

        Instantiate(levelList[PlayerPrefs.GetInt("Level")], transform.position, Quaternion.identity);
    }

    // constantly checks if player is too small to live or not
    private void TooSmallToLive()
    {
        if (candleScore <= 1)
        {
            playerManager.MeltToDeath();
            playerManager.gameObject.SetActive(false);
            Invoke("OnLevelFailed", 0.8f);
        }
    }

    // plays sfx when player dies
    public void PlayFailSound()
    {
        bool alreadyPlaying = false;

        if (alreadyPlaying==false)
        {
            audioSource.PlayOneShot(fail);
            alreadyPlaying = true;
        }
        
    }

    
}
