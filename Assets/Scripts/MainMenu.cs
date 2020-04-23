using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject logoImage;
    public GameObject playButton;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject selectButton;

    public void playButtonClicked()
    {
        logoImage.SetActive(false);
        playButton.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        selectButton.SetActive(true);
    }
}
