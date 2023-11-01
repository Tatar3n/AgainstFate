using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float len, startpos;
    public GameObject cam;
    public float parallaxEffect;
    private void Start()
    {
        startpos = transform.position.x;
        len = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
    
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + len)
            startpos += len;
        else if (temp < startpos - len)
            startpos -= len;
    }

}
