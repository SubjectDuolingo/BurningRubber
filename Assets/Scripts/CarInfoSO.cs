using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CarInfoSO")]
public class CarInfoSO : ScriptableObject
{
    public GameObject selectedCar;

    public void SelectNewCar(GameObject car)
    {
        selectedCar = car;
    }
}
