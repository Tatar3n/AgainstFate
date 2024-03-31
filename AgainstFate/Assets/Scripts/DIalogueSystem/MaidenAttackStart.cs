using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidenAttackStart : MonoBehaviour
{
    Animator a;
    EnemyLogic maiden;
    public Pattern p;
    private void Start()
    {
        a = GetComponent<Animator>();
        maiden = GetComponent<EnemyLogic>();
    }

    private void Update()
    {
        if (p.IsEnd)
        {
            a.enabled = true;
            maiden.enabled = true;
        }


    }


}
