using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverText : MonoBehaviour
{
    public GameObject levertext;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            levertext.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            levertext.SetActive(false);
        }
    }
}
