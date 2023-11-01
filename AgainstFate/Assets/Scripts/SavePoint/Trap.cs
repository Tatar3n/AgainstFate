using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public float damageCount = 10;//кол-во урона ловушки
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Respawn>().RespawnPlayer();
            collision.gameObject.GetComponent<HP>().Damaging(damageCount);
        }
    }
}
