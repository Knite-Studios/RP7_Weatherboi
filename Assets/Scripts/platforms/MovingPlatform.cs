using Percy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPoint = 0;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float waitTime = 1f;

    private bool isWaiting = false;
    private float waitTimer = 0f;
    PlayerController player;
    private void Start()
    {
         player = FindObjectOfType<PlayerController>();
        if(wayPoints.Length == 0)
        {
            Debug.LogError("No waypoints set for moving platform");
        }
    }
    void Update()
    {
        if (!isWaiting)
        {
            if (transform.position != wayPoints[currentWayPoint].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
            }
            else
            {
                isWaiting = true;
                waitTimer = waitTime;
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                currentWayPoint = (currentWayPoint + 1) % wayPoints.Length;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(transform);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
