using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public Slingshot slingshot;
    
    public GameObject bottomPanel;
    public GameObject startButton;
    public GameObject tryAgainButton;

    public TextMeshProUGUI scoreText;

    private int _score;

    void Start()
    {
        _score = 0;
    }

    ///<summary>Begin the game.</summary>
    public void StartGame()
    {
        slingshot.gameObject.SetActive(true);
        bottomPanel.SetActive(true);
        startButton.SetActive(false);
    }

    ///<summary>Reset the score, ammo, and targets.</summary>
    public void StartAgain()
    {
        slingshot.gameObject.SetActive(true);
        slingshot.ResetAmmo();
        _score = 0;
        scoreText.text = "Score";
        tryAgainButton.SetActive(false);
    }

    public void AddScore()
    {
        _score += 10;
        scoreText.text = $"{_score}";
    }

    public void GameOver()
    {
        tryAgainButton.SetActive(true);
        slingshot.gameObject.SetActive(false);
    }
}
