using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAfterKillCave : MonoBehaviour
{
    private float wait = 0.1f;
    private bool flag;
    private bool flag2;
    public GameObject obj;
    public int direction;
    public float freezeTime = 1.0f;

    private void Start()
    {
        flag2 = false;
        flag = false;
    }

    public void FixedUpdate()
    {
        if (flag)
        {
            wait -= Time.deltaTime;
            freezeTime -= Time.deltaTime;
        }

        if (gameObject.GetComponent<CaveThrowBullet>().isDead && !flag)
        {
            obj.GetComponent<PlayerMovement>().isFreezing = true;
            flag = true;
        }

        if (wait < 0 && !flag2)
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 1500 * direction);
            flag2 = true;
        }

        if (freezeTime < 0 && obj.GetComponent<PlayerMovement>().isFreezing)
        {
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            obj.GetComponent<PlayerMovement>().isFreezing = false;
        }

    }
}
