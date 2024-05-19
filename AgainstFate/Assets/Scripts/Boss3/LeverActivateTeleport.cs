using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivateTeleport : MonoBehaviour
{
    private bool fl = true;
   
    public GameObject teleport;
    private LeverController lc;
    private void Start()
    {
        lc = GetComponent<LeverController>();
    }
    private void Update()
    {
        if(fl && lc._fall)
        {
            teleport.SetActive(true);
        }
    }
}
