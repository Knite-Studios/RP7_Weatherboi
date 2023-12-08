using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    GameObject spikePrefab; // Reference to the spike GameObject
    [SerializeField]
    Transform spawnPoint; // Point where spikes will spawn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            ShootSpike();
        }
    }

    void ShootSpike()
    {
        GameObject newSpike = Instantiate(spikePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
