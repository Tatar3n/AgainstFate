using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterAriaDeath : MonoBehaviour
{
    public GameObject aria;
    public GameObject doors;
    public GameObject way;
    // Update is called once per frame
    void Update()
    {
        if (aria == null)
        {
            doors.SetActive(false);
            way.SetActive(true);

        }
    }
}
