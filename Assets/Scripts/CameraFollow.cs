using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);     
        transform.position = smoothedPosition + (-target.transform.forward * offset.magnitude);
        transform.LookAt(target);
    }
}
