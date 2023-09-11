using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private const string mainMenu = "MainMenu";
    private const string gamePlay = "GamePlayScene";
    public bool isInitialize {  get; set; }
    public int currentScore {  get; set; }
    private string highScoreKey = "HighScore";
    public int highScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        currentScore = 0;
        isInitialize = false;
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }

    public void GoToGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gamePlay);
    }
}
