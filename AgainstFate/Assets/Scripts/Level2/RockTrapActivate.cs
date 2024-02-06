using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrapActivate : MonoBehaviour
{
    public GameObject[] p;
    public GameObject player;
    static int size = 4;
    Vector3[] v = new Vector3[size];
    Rigidbody2D[] rb = new Rigidbody2D[size];
    float t;
    bool f = false;
    int ii = 0;
   
    Respawn re;
    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            v[i] = p[i].transform.position;
            rb[i] = p[i].GetComponent<Rigidbody2D>();
        }
        re = player.GetComponent<Respawn>();
    }

    private void Update()
    {
        if(Time.time - t> 0.5 && f && ii<size)
        {
           
                rb[ii].isKinematic = false;
                ii++;
                t = Time.time;

           
        }
        if(re.recoverRockTrap)
        {
            ii = 0;
            f = false;
            re.recoverRockTrap = false;
            for (int i = 0; i < size; i++)
            {
                p[i].transform.position = v[i];
                rb[i].bodyType = RigidbodyType2D.Static;

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            f = true;
           
        }
    }
    




}
