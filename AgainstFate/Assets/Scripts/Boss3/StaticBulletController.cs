using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBulletController : MonoBehaviour
{
    public float speed;
    public Transform point;
    private Rigidbody2D rb;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = (point.position - transform.position).normalized;
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Walls") || collision.gameObject.layer == 6)
        {
            Debug.Log("Пуля уничтожена");
            Destroy(gameObject);
        }
    }
}
