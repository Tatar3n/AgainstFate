using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public enum direction
    {
        horizontal,
        vertical
    }
    public float strength = 10f;//сила ветра
    public GameObject player;
    private Rigidbody2D rb;
    public direction Direction;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(rb!=null)
            {
                if(Direction == direction.horizontal)
                    rb.AddForce(new Vector2(strength, 0));
                else
                    rb.AddForce(new Vector2(0, strength));
            }
        }
    }
}
