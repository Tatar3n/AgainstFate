using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrapActivate : MonoBehaviour
{
    public GameObject[] p;
    public GameObject player;
    static int size = 44;
    Vector3[] v = new Vector3[size];
    Rigidbody2D[] rb = new Rigidbody2D[size];
    float t,tt;
    bool f = false;
    public static bool fl = false;
    int ii = 0;
    public static bool EndRockTrap = false;
    public AdaptedPatterForCapricorn d;
    Respawn re;

    private bool wait = true;
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
        if (d.IsEnd && !EndRockTrap)
        {
            FallingGround.start = true;
            f = true;
            StartCoroutine(TimeBeforeRockTRap());
            if (Time.time - t > 0.27 && f && ii < size && !wait)
            {
                if (!CameraShake.startshake)
                    fl = true;
                rb[ii].isKinematic = false;
                ii++;
                t = Time.time;
                if (ii == rb.Length - 1)
                    EndRockTrap = true;


            }
            if (re.recoverRockTrap)
            {
                fl = true;
                wait = true;
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

        IEnumerator TimeBeforeRockTRap()
        {
            yield return new WaitForSeconds(1);
            wait = false;
        }


    }
   
    




}
