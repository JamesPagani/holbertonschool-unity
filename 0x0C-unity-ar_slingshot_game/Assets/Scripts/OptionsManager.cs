using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    ///<summary>Restart the whole game. RESTARTING MEANS HAVING TO SELECT A PLANE AGAIN.<summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    ///<summary>Exit the game.</summary>
    public void Exit()
    {
        Application.Quit();
    }
}
