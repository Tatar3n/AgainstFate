using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLiftUp : MonoBehaviour
{
    public MovingPlatformUpDown m;
    public float stoppos;
    public PlayerMovement player;
    private void FixedUpdate()
    {
        if (transform.position.y >= stoppos)
        {
            m.enabled = false;
           
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m.enabled = true;
            player.isDialog = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {

            m.enabled = false;
            player.isDialog = false;
        }
    }
}
