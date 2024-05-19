using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedoors : MonoBehaviour
{
    public GameObject door1, door2;
    private Animator a1, a2;
    private BoxCollider2D b1, b2;
    private void Start()
    {
        a1 = door1.GetComponent<Animator>();
        a2 = door2.GetComponent<Animator>();
        b1 = door1.GetComponent<BoxCollider2D>();
        b2 = door2.GetComponent<BoxCollider2D>();

    }
    public enum door_state
    {
        open, close
    }
    public door_state Door_State;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Door_State == door_state.open)
            {
                b1.enabled = false;
                b2.enabled = false;
                a1.Play("doorboss1");
                a2.Play("doorboss1");
            }
            else
            {
                b1.enabled = true;
                b2.enabled = true;
                a1.Play("doorboss1close");
                a2.Play("doorboss1close");
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Door_State == door_state.open)
            {
                b1.enabled = false;
                b2.enabled = false;
                a1.Play("doorboss1");
                a2.Play("doorboss1");
            }
            else
            {
                b1.enabled = true;
                b2.enabled = true;
                a1.Play("doorboss1close");
                a2.Play("doorboss1close");
            }
        }
    }
}
