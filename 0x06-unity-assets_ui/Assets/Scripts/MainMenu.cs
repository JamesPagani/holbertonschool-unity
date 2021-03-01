using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /* Loads a level, based on the build settings.
     * INDEX:
     *  0: Main Menu.
     *  1: Options.
     *  2 to 4: Levels 1 to 3.
     */
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    // Loads the options.
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Quits the game.
    public void Exit()
    {
        Application.Quit();
    }
}
