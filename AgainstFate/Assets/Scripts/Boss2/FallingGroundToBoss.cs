using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroundToBoss : MonoBehaviour
{
    public BoxCollider2D bx_shake, bx_expl;
    public GameObject shake;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Start_Shake());
           
        }

    }

    IEnumerator Start_Shake()
    {
        yield return new WaitForSeconds(2f);
        shake.SetActive(true);
        bx_expl.enabled = true;
    }
}
