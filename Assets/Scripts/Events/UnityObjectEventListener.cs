using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityObjectEventListener : MonoBehaviour, IGameObjectEventListener
{
    [SerializeField]
    private ObjectEvent objectEvent;

    [SerializeField]
    private UnityEvent<GameObject> response;

    public void OnEnable()
    {
        objectEvent?.RegisterListener(this);
    }
    public void OnDisable()
    {
        objectEvent?.UnregisterListener(this);
    }
    public void OnEventRaised(GameObject gameObject)
    {
        response?.Invoke(gameObject);
    }
}

public interface IGameObjectEventListener
{
    void OnEventRaised(GameObject gameObject);
}
