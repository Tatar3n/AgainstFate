using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideFloor : MonoBehaviour
{

    public Rigidbody2D rb;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            rb.gravityScale = 20;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            rb.gravityScale = 1;
    }
}
