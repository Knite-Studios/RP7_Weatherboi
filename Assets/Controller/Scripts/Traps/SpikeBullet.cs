using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BreakableSpikeWall wall))
        {
            wall.Break();
            Destroy(gameObject);
        }
    }
}

