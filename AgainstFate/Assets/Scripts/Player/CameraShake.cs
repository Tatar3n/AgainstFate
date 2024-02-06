using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera maincam;
    float shakeAmount = 0;
    BoxCollider2D bx;
    bool startshake = false;
    private void Awake()
    {
        if (maincam == null)
            maincam = Camera.main;
        bx = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (startshake)
            Shake(0.01f, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            startshake = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            startshake = false;
    }

    void Shake(float amt,float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }
    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = maincam.transform.position;
            float x = Random.value * shakeAmount *2 - shakeAmount;
            float y = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += x;
            camPos.y += y;

            maincam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        maincam.transform.localPosition = Vector3.zero;
    }

}
