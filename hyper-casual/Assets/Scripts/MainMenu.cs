using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text newScoresText;
    [SerializeField] private TMP_Text highScoreText;

    [SerializeField] private AudioClip clickClip;

    [SerializeField] private float animationTime;
    [SerializeField] private AnimationCurve speedCurve;

    private void Awake()
    {
        if(GameManager.Instance != null)
        {

        }
        else
        {
            scoreText.gameObject.SetActive(false);
            newScoresText.gameObject.SetActive(false);
            highScoreText.text = GameManager.Instance.highScore.ToString();
        }
    }

    public void ClickedPlay()
    {
        SoundManager.instance.PlaySound(clickClip);
        GameManager.Instance.GoToGamePlay();
    }

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.currentScore;
        int highScore = GameManager.Instance.highScore;

        if(highScore < currentScore)
        {
            newScoresText.gameObject.SetActive(true);
            GameManager.Instance.highScore = currentScore;
        }
        else
        {
            newScoresText.gameObject.SetActive(false);
        }

        highScoreText.text = GameManager.Instance.highScore.ToString();

        float speed = 1 / animationTime;
        float timeEsplased = 0f;

        while(timeEsplased < speed)
        {
            timeEsplased += Time.deltaTime;
            tempScore = (int)(speedCurve.Evaluate(timeEsplased) * currentScore);
            scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        scoreText.text = tempScore.ToString() ;
    }
}
