using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformUp : MonoBehaviour
{
    public MovingPlatformUpDown m;
    public float stoppos;
    public BoxCollider2D b1;
    public BoxCollider2D b2;
    private void FixedUpdate()
    {
        if (transform.position.y  >= stoppos)
        {
            m.enabled = false;
            b1.enabled = false;
            b2.enabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m.enabled = true;
            b1.enabled = true;
            b2.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {

            m.enabled = false;
            b1.enabled = false;
            b2.enabled = false;
        }
    }
}
