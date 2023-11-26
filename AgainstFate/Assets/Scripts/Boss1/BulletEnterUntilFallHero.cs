using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnterUntilFallHero : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bp;
    public Transform bp1;
    public Transform bp2;
    public Transform bp3;

    public void Spawn()
    {
        Instantiate(Bullet, bp);
        Instantiate(Bullet, bp1);
        Instantiate(Bullet, bp2);
        Instantiate(Bullet, bp3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Spawn();
    }
}
