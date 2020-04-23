﻿using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public float timeLeft;
    private float initialCountdown = 4f;
    public Text gameTimer;
    public Text countdownTimer;
    public GameObject player;
    public GameObject carSpawnerManager;

    void Update()
    {
        if (player == null)
        {
            player = carSpawnerManager.GetComponent<CarSpawner>().newCar;
            player.GetComponent<CarController>().enabled = false;

        }        
        else
        {
            InitialCountdown();
            if (initialCountdown < 0)
            {
                countdownTimer.text = "Start!";
                player.GetComponent<CarController>().enabled = true;
                if (initialCountdown < -3)
                {
                    countdownTimer.text = "";
                }
                GameTimer();
            }
        }
    }

    void InitialCountdown() 
    {
        initialCountdown -= Time.deltaTime;
        countdownTimer.text = Mathf.FloorToInt(initialCountdown % 60F).ToString("0");
    }

    void GameTimer() 
    {
        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft % 60F);
        int milliseconds = Mathf.FloorToInt((timeLeft * 100F) % 100F);
        gameTimer.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        if (timeLeft < 0)
        {
            timeLeft = 0f;
            countdownTimer.text = "Time's up!";
            player.GetComponent<CarController>().enabled = false;
        }
    }


}
