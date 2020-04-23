using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    public bool isHit = false;
    public AudioSource AudioSource;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CarController>() != null)
        {
            isHit = true;
            AudioSource.Play();
        }
    }
}
