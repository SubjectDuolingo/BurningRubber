using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntSystem : MonoBehaviour
{
    public GameEventSO stunt_barrelRoll;
    public GameEventSO stunt_airTime;
    public GameEventSO stunt_binHit;

    public List<WheelGroundChecker> wheelScripts;

    public bool binHit = false;

    public bool isGrounded;
    public bool barrelRollPerformed = false;

    public float minimumAirTime = 0.5f;
    private float airTimer = 0f;
    public bool airTimePerformed = false;

    private void Update()
    {
        isGrounded = CheckAllWheelsGrounded();
        CheckForStunts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<GarbageBin>() != null)
        {
            if(collision.gameObject.GetComponent<GarbageBin>().isHit == false)
            {
                binHit = true;
            }
        }
    }

    private void CheckForStunts()
    {
        if (transform.localRotation.z > 0.65f)
        {
            barrelRollPerformed = true;
        }

        if (!isGrounded)
        {
            airTimer += Time.deltaTime;
            if (airTimer >= minimumAirTime && barrelRollPerformed == false)
            {
                airTimePerformed = true;
            }
        }
        else
        {
            airTimer = 0f;
        }

        if(airTimePerformed && isGrounded)
        {
            stunt_airTime.Raise();
            airTimer = 0f;
            airTimePerformed = false;
        }

        if (barrelRollPerformed && isGrounded)
        {
            stunt_barrelRoll.Raise();
            barrelRollPerformed = false;
        }

        if(binHit)
        {
            stunt_binHit.Raise();
            binHit = false;
        }
    }

    private bool CheckAllWheelsGrounded()
    {
        bool allWheelsOnGround = true;
        for (int i = 0; i < wheelScripts.Count; i++)
        {
            if (wheelScripts[i].WheelOnGround == false)
            {
                allWheelsOnGround = false;
            }
        }

        return allWheelsOnGround;
    }
}
