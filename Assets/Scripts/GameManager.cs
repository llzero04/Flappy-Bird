using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public GameObject GameOverPanel;
    public Text scoreText;
    public Text gameOverScoreText;

    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        changeScoreText();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void incrementScore(int val)
    {
        score += val;
        changeScoreText();
        // Debug.Log(score.ToString());
    }

    public void gameOver()
    {
        scoreText.text = "";
        GameOverPanel.SetActive(true);

        highScore = highScore >= score ? highScore : score;
        PlayerPrefs.SetInt("HighScore", highScore);

        gameOverScoreText.text = "Your Score : " + score.ToString() + "\n\n" + "Your High Score : " + highScore.ToString();
    }

    public void resetLevel()
    {
        // Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        // Debug.Log("Quit");
        Application.Quit();
    }
}
