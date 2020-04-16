using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public CarInfoSO carSpawnInfo;
    public GameObject cameraParent;
    public GameObject newCar;

    void Start()
    {
        newCar = Instantiate(carSpawnInfo.selectedCar);
        cameraParent.GetComponent<CarCam>().car = newCar;
        cameraParent.GetComponent<CarCam>().carPhysics = newCar.GetComponent<Rigidbody>(); 
    }
}
