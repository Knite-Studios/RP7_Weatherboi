using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public bool canPause = true;

    int keyscollected = 0;
    public int KeysNeeded = 3;

    public UnityEvent OpenExit;
    bool isOpen = false;

    void Start()
    {
      
    }
    public void CollectedKey()
    {
        keyscollected++;
    }
    void CheckKeys()
    {
        if ((keyscollected == KeysNeeded || Input.GetKeyDown(KeyCode.P)) && !isOpen)
        {
            isOpen = true;
            OpenExit.Invoke();
            
        }
    }
    void Update()
    {
        CheckKeys();   
    }
}
