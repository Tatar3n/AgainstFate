using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4HP : MonoBehaviour
{
    [SerializeField] private float hp = 150;

    public float GetHP()
    {
        return hp;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            StartCoroutine(Death());
        }

    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
    }
}
