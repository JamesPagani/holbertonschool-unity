using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [HideInInspector] public int previousScene;
    public Toggle invertYAxis;

    public void Start()
    {
        previousScene = PlayerPrefs.GetInt("prevScene", 0);
        invertYAxis.isOn = PlayerPrefs.GetInt("yInverted", 0) == 1 ? true : false;
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("yInverted", invertYAxis.isOn ? 1 : 0);
        SceneManager.LoadScene(previousScene);
    }

    //Returns to the previously loaded scene.
    public void Back()
    {
        SceneManager.LoadScene(previousScene);
    }
}
