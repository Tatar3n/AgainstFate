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
    public GameObject savepoint;
    Respawn re;

    public GameObject rock;
    private bool isPreparationEnd = true;
    private bool wait = true;
    List<GameObject> rocks;

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
            StartCoroutine(TimeBeforeRockTRap());
            if (Time.time - tt > 4 && !f)
            {
               
                f = true;
                wait = false;
                tt = Time.time;
            }
           

            if (Time.time - t > 0.25 && f && ii < size && !wait)
            {
                //if(isPreparationEnd)
                //{
                //    rocks.Add(Instantiate(rock, new Vector3(26.14f,-4.86f,0f), Quaternion.identity));
                //    StartCoroutine(Waiting());
                //}
               
                if (!CameraShake.startshake)
                    fl = true;
                rb[ii].isKinematic = false;
                ii++;
                
                t = Time.time;
              
                if (ii == rb.Length - 1 && player.transform.position.x <= savepoint.transform.position.x || player.transform.position.x <= savepoint.transform.position.x)
                {
                    CameraShake.startshake = false;
                    EndRockTrap = true;
                }
            }
            if (re.recoverRockTrap)
            {
                //rocks.ForEach(Destroy);
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
            yield return new WaitForSeconds(3);

            f = true;
            wait = false;
        }
        IEnumerator Waiting()
        {
            isPreparationEnd = false;
            yield return new WaitForSeconds(10f); // Задержка в 10 секунд
            isPreparationEnd = true;
        }


    }
   
    




}
