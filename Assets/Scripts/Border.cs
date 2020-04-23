using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public AudioSource snowAudio;
    private AudioSource[] allAudio;

    private void Start()
    {
        allAudio = FindObjectsOfType<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        foreach(AudioSource audio in allAudio)
        {
            audio.Stop();
        }
        if(snowAudio.isPlaying == false)
        {
            snowAudio.Play();
        }
    }
}
