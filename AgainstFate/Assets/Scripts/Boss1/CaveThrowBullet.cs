using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveThrowBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bp;
    private float updateTime = 2.5f;
    private float attackTime = 0.3f;
    int i = 0;
    public bool isAttack;
    public bool isDead;
    public GameObject door;
    Animator a;

    private BoxCollider2D bx;
    private void Start()
    {
        bx = door.GetComponent<BoxCollider2D>();
        a = door.GetComponent<Animator>();
    }
    public void Spawn()
    {
        Instantiate(Bullet, bp);
    }

	public void Update()
	{
        if (isDead)
        {
            a.Play("doorboss1close");
            bx.enabled = true;
            isAttack = false;
            
        }

        if (isAttack)
        {
            a.Play("doorboss1");
            bx.enabled = false;
            gameObject.layer = 8;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            updateTime -= Time.deltaTime;
            attackTime -= Time.deltaTime;
            if (updateTime < 0)
            {
                if (attackTime < 0)
                {
                    Spawn();
                    attackTime = 0.3f;
                    i++;
                }
                if (i == 3)
                {
                    updateTime = 2.5f;
                    i = 0;
                }
            }
        }
        else
        {
            a.Play("doorboss1close");
            bx.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public bool IsAttack()
    {
        return isAttack;
    }

}
