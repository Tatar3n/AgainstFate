using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExpl : MonoBehaviour
{
    public GameObject shake;
    public GameObject expl;
    public GameObject floor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Start_Expl());
           
        }

    }
    IEnumerator Start_Expl()
    {
        yield return new WaitForSeconds(2f);
        expl.SetActive(true);
        shake.SetActive(false);
        floor.SetActive(false);
    }
}
