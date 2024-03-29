using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public static bool start;
    float  pos2 = -19.5f;
    public GameObject ground, platforms_1,explosion;
    float speed = 4f;
    private void FixedUpdate()
    {
        if (start)
        {
            ground.SetActive(false);
            platforms_1.SetActive(false);
            explosion.SetActive(true);
        }
    }
}
