using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEventSO EventSO;
    public UnityEvent response;

    public void OnEnable()
    {
        EventSO.RegisterListener(this);
    }

    public void OnDisable()
    {
        EventSO.RemoveListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
