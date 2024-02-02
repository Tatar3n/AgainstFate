using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAndWhiteScreen : MonoBehaviour
{
    public GameObject dark;
    public GameObject white;
   void  OnTriggerEnter2D(Collider2D collisison)
    {
        if (collisison.tag == "Player")
        {
            dark.SetActive(false);
            white.SetActive(true);
        }
    }

}
