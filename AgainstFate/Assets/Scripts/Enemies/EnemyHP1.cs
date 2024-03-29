using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP1 : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    void Update()
    {
        if (hp <= 0)
            GameObject.Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
    }
}
