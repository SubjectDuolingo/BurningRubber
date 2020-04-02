using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGroundChecker : MonoBehaviour
{
    public bool WheelOnGround;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<Floor>() != null)
        {
            WheelOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    { 
        if(collision.gameObject.GetComponent<Floor>() != null)
        {
            WheelOnGround = false;
        }
    }
}
