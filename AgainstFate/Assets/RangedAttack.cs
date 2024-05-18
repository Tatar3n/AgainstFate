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
        if (hitInfo.gameObject.layer == 9)
        {
            var enemy = hitInfo.GetComponent<Boss2HP>();
            if (enemy != null)
            {
                enemy.GetComponent<Boss2HP>().GetDamage(damage);
            }
        }
       
        else
        {
            var enemy = hitInfo.GetComponent<EnemyHP1>();
            var enemy1 = hitInfo.GetComponent<GeminiHP>();
            var enemy2 = hitInfo.GetComponent<LibraHP>();
            if (enemy != null)
            {
                enemy.GetComponent<EnemyHP1>().GetDamage(damage);
            }
           
            else if(enemy1!=null)
            {
               
                enemy1.GetComponent<GeminiHP>().GetDamage(damage);
            }
            else if (enemy2 != null)
            {

                enemy2.GetComponent<LibraHP>().GetDamage(damage);
            }
        }
        
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log(hitInfo.name);
        
        Destroy(gameObject);
    }
}
