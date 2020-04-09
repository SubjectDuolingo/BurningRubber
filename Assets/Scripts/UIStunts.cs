using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStunts : MonoBehaviour
{
    public Text stuntsText;
    public Text scoreText;
    public float score;

    public float stuntTextShowTime = 0;
    private float timeLeft = 0;

    public void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            stuntsText.enabled = false;
        }
    }

    public void ShowStuntsText(string stuntText)
    {
        timeLeft = stuntTextShowTime;
        if (stuntsText.enabled)
        {
            stuntsText.fontSize = 36;
            stuntsText.text += "\n" + stuntText;
        }
        else
        {
            stuntsText.fontSize = 50;
            stuntsText.enabled = true;
            stuntsText.text = stuntText;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
}
