using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingAndDestroyedPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentposition;
    

    public LeverController leverController;
    public float time = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        currentposition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (leverController._fall)
        {
            
            Invoke("FallPlatform", time);
            Destroy(gameObject, time+1);
        }
    }
    void FallPlatform()
    {
        rb.isKinematic = false;
        
    }
}
