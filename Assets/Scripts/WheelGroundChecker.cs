using UnityEngine;

public class WheelGroundChecker : MonoBehaviour
{
    public bool WheelOnGround;
    private WheelCollider WheelCollider;

    private void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    private void Update()
    {
        if (WheelCollider.GetGroundHit(out WheelHit wheel))
        {
            WheelOnGround = true;           
        }
        else
        {
            WheelOnGround = false;
        }
    }
}
