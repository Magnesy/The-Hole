using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    //[SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject gameOverDisplay;
    private int maxLevel = 10;

    public const string LevelKey = "Level";
    public const string LastLevelKey = "LastLevel";

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        int level = PlayerPrefs.GetInt(LevelKey, 1);
        if(level < maxLevel)
        {
            level = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt(LevelKey , level);
            SceneManager.LoadScene(level);
        }
        else 
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
