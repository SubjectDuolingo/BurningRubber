using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public float timeLeft;
    private float initialCountdown = 4f;
    public Text gameTimer;
    public Text countdownTimer;
    public GameObject player;
    public GameObject carSpawnerManager;
    public AudioSource gameOverAudio;
    public AudioSource startAudio;
    public GameObject mainMenuButton;
    private AudioSource[] allAudio;
    private int check = 0;

    void Start()
    {
        if (startAudio.isPlaying == false)
        {
            startAudio.Play(120000);
        }
        allAudio = FindObjectsOfType<AudioSource>();
    }

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
            if (initialCountdown < 1)
            {
                countdownTimer.text = "Start!";
                player.GetComponent<CarController>().enabled = true;
                if (initialCountdown < 0)
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
            for (int i = check; i < 1; i++)
            {
                foreach (AudioSource audio in allAudio)
                {
                    audio.Stop();
                }
                if (gameOverAudio.isPlaying == false)
                {
                    gameOverAudio.Play();
                }
                check = 1;
            }
            timeLeft = 0f;
            countdownTimer.text = "Game Over!";
            player.GetComponent<CarController>().enabled = false;
            mainMenuButton.SetActive(true);
        }
    }

    public void mainMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
