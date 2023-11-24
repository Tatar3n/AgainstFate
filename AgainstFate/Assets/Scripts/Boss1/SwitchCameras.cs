using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera actual;
    public Camera next;

    public void Switch()
    {
        Debug.Log("Работает");
        actual.enabled = false;
        next.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           this.Switch();
        }
    }
}

