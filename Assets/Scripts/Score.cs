using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text stuntText;
    [SerializeField] private float score;

    private float points;
    private float timeLeft;

    void Start()
    {
        timeLeft = 0;
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            stuntText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        stuntText.enabled = true;
        timeLeft = 2;
        stuntText.text = "Ramp jump! +" + score.ToString();
        scoreText.text = "Score: " + (points += score).ToString();
    }
}
