using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMover : MonoBehaviour
{
    public void RightButtonClicked()
    {
        gameObject.transform.Rotate(new Vector3(0, -90, 0));
    }

    public void LeftButtonClicked()
    {
        gameObject.transform.Rotate(new Vector3(0, 90, 0));
    }
}
