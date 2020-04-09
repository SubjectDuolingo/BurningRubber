using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public CarInfoSO carObject;
    public List<GameObject> carList = new List<GameObject>();
    public int selectedCar = 0;
    public int totalCars;

    private void Start()
    {
        totalCars = (carList.Count - 1);
    }

    public void RightButtonClicked()
    {
        gameObject.transform.Rotate(new Vector3(0, -90, 0));
        if(selectedCar < totalCars)
        {
            selectedCar++;
        }
        else
        {
            selectedCar = 0;
        }
    }

    public void LeftButtonClicked()
    {
        gameObject.transform.Rotate(new Vector3(0, 90, 0));
        if (selectedCar > 1)
        {
            selectedCar--;
        }
        else
        {
            selectedCar = totalCars;
        }
    }

    public void SelectCarButtonClicked()
    {
        carObject.SelectNewCar(carList[selectedCar]);
    }
}
