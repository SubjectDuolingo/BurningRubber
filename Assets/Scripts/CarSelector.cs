using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    public CarInfoSO carObject;
    public List<GameObject> carList = new List<GameObject>();
    public int selectedCar = 0;
    public int totalCars;
    public Button left;
    public Button right;

    private void Start()
    {
        totalCars = (carList.Count - 1);
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        right.interactable = true;
        left.interactable = true;
    }


    public void RightButtonClicked()
    {
        right.interactable = false;
        left.interactable = false;
        StartCoroutine(RotateMe(Vector3.up * -90, 1.4f));
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
        left.interactable = false;
        right.interactable = false;
        StartCoroutine(RotateMe(Vector3.up * 90, 1.4f));
        if (selectedCar > 0)
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
        SceneManager.LoadScene(1);
    }
}
