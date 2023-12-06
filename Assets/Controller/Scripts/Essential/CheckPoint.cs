using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector2 _spawnPoint;
    private void Awake()
    {
        _spawnPoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.TryGetComponent(out PlayerHealth playerHealth))
      {
        playerHealth.SetSpawnPoint(_spawnPoint);
      }
    }
}
