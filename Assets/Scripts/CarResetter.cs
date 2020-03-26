using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarResetter : MonoBehaviour
{
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    void Start()
    {
        spawnPosition = gameObject.transform.position;
        spawnRotation = gameObject.transform.rotation;
    }

    void Update()
    {
        checkReset();
    }

    void checkReset()
    {
        if(Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = spawnPosition;
            gameObject.transform.rotation = spawnRotation;
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
