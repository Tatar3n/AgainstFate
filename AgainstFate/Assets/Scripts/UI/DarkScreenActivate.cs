using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScreenActivate : MonoBehaviour
{
    public GameObject o;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            o.SetActive(true);
    }
}
