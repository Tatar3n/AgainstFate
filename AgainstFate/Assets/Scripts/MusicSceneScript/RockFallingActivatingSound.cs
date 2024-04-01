using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockFallingActivatingSound : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Event.PlaySound(0, 1, false, false, 1, 1);
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Event.PlaySound(1, 1, false, false, 1, 1);
        }
    }



    public Sounds Event;
}

