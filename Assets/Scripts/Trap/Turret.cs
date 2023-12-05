using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject spikePrefab; // Reference to the spike GameObject
    public Transform spawnPoint; // Point where spikes will spawn
    public float shootForce = 10f; // Force to shoot the spike

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Example: Trigger shooting with Space key (you can change this condition)
        {
            ShootSpike();
        }
    }

    void ShootSpike()
    {
        GameObject newSpike = Instantiate(spikePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D spikeRB = newSpike.GetComponent<Rigidbody2D>();// Get the Rigidbody component from the spike

        if (spikeRB != null)
        {
            spikeRB.AddForce(spawnPoint.up * shootForce, ForceMode2D.Impulse); // Use 'up' for 2D force direction
        }
    }
}
