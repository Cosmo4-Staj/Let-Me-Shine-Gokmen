using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() // starts the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale=1;
    }

    public void QuitGame() // quits from the app
    {
        Debug.Log("game closed");
        Application.Quit();
    }
}
