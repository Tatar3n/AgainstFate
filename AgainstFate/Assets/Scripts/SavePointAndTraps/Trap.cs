using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public float damageCount = 10;//кол-во урона ловушки
    public float timeReLoad = 1;//время перезарядки ловушки
    private bool isReLoad = false;//ловушка активна или перезаряжается?
    //public float forceUp = 2;//сила отброса от ловушки
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Respawn>().RespawnPlayer();
            Action(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Respawn>().RespawnPlayer();
            Action(collision);
        }
    }
    private void Action(Collider2D collision)
    {
        if (isReLoad)
            return;
        StartCoroutine(Reload());

        //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        //Vector3 force = collision.transform.position - transform.position;
        //force.Normalize();
        //force += Vector3.up;
        //force *= forceUp;
        //rb.Sleep();
        //rb.AddForce(force, ForceMode2D.Impulse);
        collision.gameObject.GetComponent<HP>().Damaging(damageCount);
    }
    private IEnumerator Reload()
    {
        isReLoad = true;
        yield return new WaitForSeconds(timeReLoad);
        isReLoad = false;
    }
}
