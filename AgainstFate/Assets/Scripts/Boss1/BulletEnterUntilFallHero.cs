using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnterUntilFallHero : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public Transform bp;
    public Transform bp1;
    public Transform bp2;
    public Transform bp3;

    public void Spawn()
    {
        Instantiate(Bullet, bp);
        Instantiate(Bullet1, bp1);
        Instantiate(Bullet2, bp2);
        Instantiate(Bullet3, bp3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Spawn();
    }
}
