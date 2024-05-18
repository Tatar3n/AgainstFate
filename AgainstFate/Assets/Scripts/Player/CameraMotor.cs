﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    public Transform target;
    public float boundx;
    public float boundy;
    public float yOffset = 0f;
    public bool lockCameraY = false;
    private float lastY;

    private void LateUpdate()
    {
        Vector2 delta = new Vector2(0, 0);

        float deltaX = target.position.x - (transform.position.x);
        if (deltaX > boundx || deltaX < -boundx)
        {
            if (transform.position.x < target.position.x)
            {
                delta.x = deltaX - boundx;
            }
            else
            {
                delta.x = deltaX + boundx;
            }
        }
        if (!lockCameraY)
        {
            float deltaY = target.position.y - (transform.position.y);
            if (deltaY > boundy || deltaY < -boundy)
            {
                if (transform.position.y < target.position.y)
                {
                    delta.y = deltaY - boundy;
                }
                else
                {
                    delta.y = deltaY + boundy;
                }
            }
            lastY = delta.y;
        }
        else delta.y = lastY;

        if (!lockCameraY)
            transform.position += new Vector3(delta.x, delta.y + yOffset, 0);
        else
        {
            transform.position += new Vector3(delta.x, 0, 0);
        }
        
    }
}
