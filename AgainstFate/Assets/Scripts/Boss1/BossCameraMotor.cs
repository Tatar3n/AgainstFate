using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCameraMotor : MonoBehaviour
{
    public Transform target;
    public float boundy;

    private void LateUpdate()
    {
        Vector2 delta = new Vector2(0, 0);

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

        transform.position += new Vector3(0, delta.y, 0);
    }
}
