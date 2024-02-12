using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeSecretWay : MonoBehaviour
{
    public GameObject ob;
    private Tilemap tl;
    private bool DoFade = false;
    float originala;
    private void Start()
    {
        tl = ob.GetComponent<Tilemap>();
        originala = tl.color.a;
    }
    private void Update()
    {
        if(DoFade)
        {
            Color currentcolor = tl.color;
            Color smoothcolor = new Color(currentcolor.r, currentcolor.g, currentcolor.b, Mathf.Lerp(currentcolor.a, 0, 5 * Time.deltaTime));
            tl.color = smoothcolor;
        }
       else
        {
            Color currentcolor = tl.color;
            Color smoothcolor = new Color(currentcolor.r, currentcolor.g, currentcolor.b, Mathf.Lerp(currentcolor.a, originala, 5 * Time.deltaTime));
            tl.color = smoothcolor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            DoFade = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.transform.position.x<transform.position.x)
            DoFade = false;
    }
}
