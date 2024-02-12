using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_Level2_ : MonoBehaviour
{
    public MovingPlatformUpDown m;
    public float time;
    public float stoppos;
    public LeverController Lever;
    

    //Vector2 currentposition;
    public PlayerMovement player;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (transform.position.y >= stoppos)
        {

            rb.isKinematic = false;
            m.enabled = false;
            player.gameObject.transform.SetParent(null);
            Destroy(gameObject, time+0.5f);
            



        }
       if( Lever._fall)
        {
            m.enabled = true;
            Lever._fall = false;
        }
    }
   



    
    
}
