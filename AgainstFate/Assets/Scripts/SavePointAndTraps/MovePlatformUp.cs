using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformUp : MonoBehaviour
{
    public MovingPlatformUpDown m;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            m.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            m.enabled = false;
    }
}
