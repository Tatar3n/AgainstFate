using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    public bool start;
    float  pos2 = -11.18f;
    public GameObject ground, platforms_1;
    float speed = 4f;
    private void FixedUpdate()
    {
        if (ground.transform.position.y >= pos2 && start)
        {
            ground.transform.position = new Vector2(ground.transform.position.x, ground.transform.position.y - speed * Time.fixedDeltaTime);
            platforms_1.SetActive(false);
           
        }
    }
}
