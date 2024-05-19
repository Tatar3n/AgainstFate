using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateauqaries : MonoBehaviour
{
    private Pattern p;
    private bool f = true;
    private void Start()
    {
        p = GetComponent<Pattern>();

    }
    public ActivateBossFight activate;
    private void Update()
        
    {
        if(f && p.IsEnd)
        {
            activate.enabled = true;
            f = false;
        }
       
    }
}
