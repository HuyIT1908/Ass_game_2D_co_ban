using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text scoreText;
    public Text gameOverScoreText;
    public GameObject gameOverText;

    public GameObject pauseText;
    public bool isGameOver = false;

    private int score = 0;

    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
        }
        else if ( instance == this )
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void Game_Over()
    {
        gameOverScoreText.text = "";
        gameOverText.SetActive(true);

        isGameOver = true;
    }

    public void pause()
    {
        pauseText.SetActive(true);

        isGameOver = true;

        Time.timeScale = 0;
    }

    public void replay()
    {
        pauseText.SetActive(false);

        isGameOver = false;
        Time.timeScale = 1;
    }

    public void intro_Welecome()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
