using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionLeave : MonoBehaviour
{
    private bool fl = true;
    private Animator a;
    public Pattern pattern;
    private void Start()
    {
        a = GetComponent<Animator>();
    }
    private void Update()
    {
        if (fl && pattern.IsEnd)
            a.enabled = true;

    }
}
