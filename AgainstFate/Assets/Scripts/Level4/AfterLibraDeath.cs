using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLibraDeath : MonoBehaviour
{
    private bool f = true;
    public GameObject g1;
    public GameObject wayaftergeminideath;
    public ADL d;

    // Update is called once per frame
    void Update()
    {
        if (d.IsEnd && f && g1 == null)
            wayaftergeminideath.SetActive(true);

    }
}
