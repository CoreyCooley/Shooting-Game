using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    public Text timerText;
    public Text scoreText;
    public GameObject gameOverPanel;

    private const int ROUND_TIME = 30;
    private int roundsShot = 0;
    private int enemyKilled = 0;
    
    private int gameTime = 0;
    public static bool gameIsPaused;

    // Use this for initialization
    void Start () {
        gameTime = ROUND_TIME;
        gameIsPaused = false;
        roundsShot = GunController.roundsShot;

        scoreText.text = enemyKilled.ToString() + " / " + roundsShot.ToString();
        InvokeRepeating("TimeCounterAction", 0.000001f, 1);	
	}
	
    void TimeCounterAction()
    {
        int timeMinutes;
        int timeSeconds;

        if (gameTime >= 0)
        {

            timeMinutes = (int)(gameTime / 60);
            timeSeconds = gameTime % 60;

            timerText.text = timeMinutes.ToString("D1") + "\' " + timeSeconds.ToString("D2") + "\"";
            gameTime--;
        }
        else
        {
            GameOver();
        }
    }

	// Update is called once per frame
	void Update () {

        roundsShot = GunController.roundsShot;
        enemyKilled = GunController.kills;

        scoreText.text = enemyKilled.ToString() + " / " + roundsShot.ToString();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
        gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
        gameOverPanel.GetComponent<CanvasGroup>().interactable = false;
        gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        gameTime = ROUND_TIME;
        GunController.Reset();
        scoreText.GetComponent<Text>().text = enemyKilled.ToString() + " / " + roundsShot.ToString();
        TimeCounterAction();
    }
}
