using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLibreAttack : MonoBehaviour
{
    Animator a;
    LibraAttackLogic maiden;
    public Pattern p;
    private void Start()
    {
        a = GetComponent<Animator>();
        maiden = GetComponent<LibraAttackLogic>();
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
