using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBulletBossController : MonoBehaviour
{
    public float speed;
    public Transform point;
    [SerializeField] private Boss4HP hp;
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
        if (collision.gameObject.layer == 14)
        {
            hp.GetDamage(50f);
            Debug.Log("Пуля уничтожена");
            Destroy(gameObject);
        }
    }
}
