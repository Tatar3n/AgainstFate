using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HP : MonoBehaviour
{
    [SerializeField] private float hp = 1000;

    public float GetHP()
    {
        return hp;
    }

    void Update()
    {
      
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
            GameObject.Destroy(gameObject);
    }
}
