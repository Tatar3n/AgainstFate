using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoStartAttack : MonoBehaviour
{
    Animator a;
    EnemyLogic leo;
    public Pattern p;
  
    private void Start()
    {
        a = GetComponent<Animator>();
        leo = GetComponent<EnemyLogic>();
    }

    private void Update()
    {
        if (p.IsEnd)
        {
            a.enabled = true;
            leo.enabled = true;
        }


    }
}
