using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSecretPlatformAfterTouch : MonoBehaviour
{
    public MovingPlatformUpDown m;
    private SpriteRenderer sp;
    float originala;
    bool DoFade = false;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        originala = 255f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m.enabled = true;
            DoFade = true;
        }
    }
    private void Update()
    {
        if (DoFade)
        {
            Color currentcolor = sp.color;
            Color smoothcolor = new Color(currentcolor.r, currentcolor.g, currentcolor.b, Mathf.Lerp(currentcolor.a, originala, 0.2f * Time.deltaTime));
            sp.color = smoothcolor;
        }
    }

}
