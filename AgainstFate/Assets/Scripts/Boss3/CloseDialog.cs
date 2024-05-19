using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
    public GameObject p;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            p.SetActive(false);
    }
}
