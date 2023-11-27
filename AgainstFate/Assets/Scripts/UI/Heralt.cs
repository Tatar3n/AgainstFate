using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heralt : MonoBehaviour
{

    public GameObject panel;
    public GameObject text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(true);
            text.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panel.SetActive(false);
            text.SetActive(false);
        }
    }
}
