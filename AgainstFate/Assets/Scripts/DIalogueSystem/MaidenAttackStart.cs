using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidenAttackStart : MonoBehaviour
{
    Animator a;
    EnemyLogic maiden;
    private void Start()
    {
        a = GetComponent<Animator>();
        maiden = GetComponent<EnemyLogic>();
    }

    private void Update()
    {
        if (Pattern.IsEnd)
        {
            a.enabled = true;
            maiden.enabled = true;
        }


    }


}
