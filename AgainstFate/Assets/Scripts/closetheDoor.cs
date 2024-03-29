using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closetheDoor : MonoBehaviour
{
    public GameObject door;
    Animator a;

    private void Start()
    {
         a = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            a.enabled = true;
    }

}
