using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    
    public float time = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("FallPlatform", time);
            Destroy(gameObject, time+2);
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
    }


}

