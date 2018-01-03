﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    public Text timerText;
    public Text scoreText;

    private int roundsShot = 0;
    private int enemyKilled = 0;

    private int gameTime = 5;

    // Use this for initialization
    void Start () {

        roundsShot = GunController.roundsShot;

        scoreText.text = enemyKilled.ToString() + " / " + roundsShot.ToString();
        InvokeRepeating("TimeCounterAction", 0.000001f, 1);	
	}
	
    void TimeCounterAction()
    {
        int timeMinutes;
        int timeSeconds;

        if (gameTime > 0)
        {

            timeMinutes = (int)(gameTime / 60);
            timeSeconds = gameTime % 60;

            timerText.text = timeMinutes.ToString("D1") + "\' " + timeSeconds.ToString("D2") + "\"";
            gameTime--;
        }
        else
        {
            Debug.Log("Game is Over");
        }
    }

	// Update is called once per frame
	void Update () {

        roundsShot = GunController.roundsShot;
        enemyKilled = GunController.kills;

        scoreText.text = enemyKilled.ToString() + " / " + roundsShot.ToString();
    }
}
