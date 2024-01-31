using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformUpDown : MonoBehaviour
{
    bool moving;
    float speed = 1f;
    public float pos1;
    public float pos2;
   
    private void FixedUpdate()
    {
        if (transform.position.y > pos1)
            moving = false;
        if (transform.position.y < pos2)
            moving = true;
        if (moving)
            transform.position = new Vector2(transform.position.x,transform.position.y + speed * Time.fixedDeltaTime);
        if (!moving)
            transform.position = new Vector2(transform.position.x,transform.position.y - speed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == null)
        {
            collision.gameObject.transform.SetParent(null);
            
        }
    }
}
