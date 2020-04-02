using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEventSO : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listenerToAdd)
    {
        listeners.Add(listenerToAdd);
    }

    public void RemoveListener(GameEventListener listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }
}
