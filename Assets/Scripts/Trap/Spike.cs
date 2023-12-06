using Percy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Spike : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerController>())
            {
                collision.GetComponent<PlayerController>().Die();
            }
        }
        else if (collision.GetComponent<BreakableWall>())
        {
            Destroy(gameObject);
        }

    }
}
