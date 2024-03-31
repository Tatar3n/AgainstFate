using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public CheckAttackCaves b;
    public GameObject expl;
 
    private void Update()
    {
        if (b.isEnd)
            expl.SetActive(true);

    }

}
