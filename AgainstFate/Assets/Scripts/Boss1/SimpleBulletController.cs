using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletController : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Rigidbody2D rb;
    private Vector3 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        direction = (player.position - transform.position).normalized;
    }

    void Update()
    {
        rb.velocity = new Vector2(direction.x * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Пуля уничтожена");
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Walls"))
            Destroy(gameObject);
    }
}
