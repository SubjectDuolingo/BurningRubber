using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntSystem : MonoBehaviour
{
    public GameEventSO stunt_barrelRoll;
    public GameEventSO stunt_airTime;

    public List<WheelGroundChecker> wheelScripts;

    public Rigidbody carRigidBody;
    public bool isGrounded;
    public bool barrelRollPerformed = false;

    public float minimumAirTime = 1f;
    private float airTimer = 0f;

    private void Update()
    {
        isGrounded = CheckAllWheelsGrounded();
        CheckForStunts();
    }

    private void CheckForStunts()
    {
        if (transform.localRotation.z > 0.8f)
        {
            barrelRollPerformed = true;
        }

        if (!isGrounded)
        {
            airTimer += Time.deltaTime;
            if (airTimer > minimumAirTime)
            {
                airTimer = 0;
                stunt_airTime.Raise();
            }
        }
        else
        {
            airTimer = 0f;
        }

        if (barrelRollPerformed && isGrounded)
        {
            stunt_barrelRoll.Raise();
            barrelRollPerformed = false;
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
