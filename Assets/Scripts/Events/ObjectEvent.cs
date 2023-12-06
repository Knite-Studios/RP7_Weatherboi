using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ObjectEvent", menuName ="Events/GameEvent")]
public class ObjectEvent : ScriptableObject
{
    private readonly List<IGameObjectEventListener> eventListeners = new List<IGameObjectEventListener>();
    public void Raise(GameObject gameObject)
    {
        foreach(IGameObjectEventListener eventListener in eventListeners)
        {
            eventListener.OnEventRaised(gameObject);
        }
    }

    public void RegisterListener(IGameObjectEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }
    public void UnregisterListener(IGameObjectEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
