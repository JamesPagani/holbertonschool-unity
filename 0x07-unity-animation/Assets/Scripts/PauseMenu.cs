using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    private Scene currentScene;

    public Canvas pauseMenu;

    private void Start()
    {
        paused = false;
        currentScene = SceneManager.GetActiveScene();
    }

    // Pauses the game.
    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        pauseMenu.gameObject.SetActive(true);
    }

    // Returns to the game
    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    // Restart the current scene
    public void Restart()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
        Resume();
    }

    // Go back to the main menu
    public void MainMenu()
    {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }

    // Go to the options menu
    public void Options()
    {
        Time.timeScale = 1;
        paused = false;
        PlayerPrefs.SetInt("prevScene", currentScene.buildIndex);
        SceneManager.LoadScene("Options");
    }

    // Handling pausing
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
                Pause();
            else
                Resume();
        }
    }
}
