using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentposition;
    bool moveingBack;
    
    public float time = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentposition = transform.position;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && moveingBack == false)
        {
            Invoke("FallPlatform", time);
            //Destroy(gameObject, time+2);
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", 5f);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveingBack = true;

    }
    private void Update()
    {
        if (moveingBack == true)
            transform.position = Vector2.MoveTowards(transform.position, currentposition, 20f * Time.deltaTime);
        if (transform.position.y == currentposition.y)
            moveingBack = false;
    }


}

