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

    public void Spawn()
    {
        Instantiate(Bullet, bp);
    }

	public void Update()
	{
        if (isDead)
            isAttack = false;

        if (isAttack)
            gameObject.layer = 8;

        if (isAttack)
        {
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
    }

    public bool IsAttack()
    {
        return isAttack;
    }

}
