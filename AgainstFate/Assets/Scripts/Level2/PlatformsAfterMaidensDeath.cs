using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsAfterMaidensDeath : MonoBehaviour
{
    public GameObject maiden;
    public GameObject platforms;
   
    // Update is called once per frame
    void Update()
    {
        if (maiden == null)
        {
            platforms.SetActive(true);
            
        }
    }
}
