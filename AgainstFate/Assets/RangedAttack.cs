using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right* speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name=="Square" || hitInfo.name=="SavePoint" ) return;
        //if (hitInfo.name != "Enemy" || hitInfo.name != "Walls") return;
        //TODO when ваня сделает врагов
        var enemy = hitInfo.GetComponent<EnemyHP1>();
        if (enemy != null)
        {
            enemy.GetComponent<EnemyHP1>().GetDamage(damage);
        }
        
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log(hitInfo.name);
        
        Destroy(gameObject);
    }
}
