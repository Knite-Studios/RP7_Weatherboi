using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BreakingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float respawnDelay = 2f;

    private Vector3 originPos;
    private bool falling = false;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.bodyType = RigidbodyType2D.Static;
        originPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Avoid calling the coroutine multiple times if it's already been called (falling)
        if (falling)
            return;

        // If the player landed on the platform, start falling
        if ((collision.gameObject.CompareTag("Player")))
        {
            StartCoroutine(StartFall());
        }
    }

    public void Break()
    {
        StartCoroutine(StartFall());
    }
    private IEnumerator StartFall()
    {
        falling = true;

        // Wait for a few seconds before dropping
        yield return new WaitForSeconds(fallDelay);
        col.enabled = false;

        // Enable rigidbody and destroy after a few seconds
        rb.bodyType = RigidbodyType2D.Dynamic;

        Invoke("Respawn", respawnDelay);
    }

    private void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Static;
        col.enabled = true;
        transform.position = originPos;
        falling = false;
    }
}

