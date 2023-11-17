using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsLeftRight : MonoBehaviour
{
    bool moving;
    public float speed = 1f;
    public float pos1;
    public float pos2;
    private void FixedUpdate()
    {
        if (transform.position.x >= pos1)
            moving = false;
        if (transform.position.x < pos2)
            moving = true;
        if (moving)
            transform.position = new Vector2(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y);
        if (!moving)
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(gameObject.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
