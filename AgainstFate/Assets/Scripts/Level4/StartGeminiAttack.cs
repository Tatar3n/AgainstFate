using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGeminiAttack : MonoBehaviour
{
    Animator a;
    GeminiAttackLogic l;
    public AdaptedPatterForCapricorn p;

    private void Start()
    {
        a = GetComponent<Animator>();
        l = GetComponent<GeminiAttackLogic>();
    }

    private void Update()
    {
        if (p.IsEnd)
        {
            a.enabled = true;
            l.enabled = true;
        }


    }
}
