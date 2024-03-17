using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTile : MonoBehaviour
{
    public GameObject player;

    LayerMask l;

    Transform tr;
    private void Start()
    {
        l = GetComponent<LayerMask>();
    }

    private void FixedUpdate()
    {
        
        if (player.transform.position.x >= transform.position.x - 0.4 || player.transform.position.x < transform.position.x+0.4)
        {
            gameObject.layer = 6;
        }
        else
            gameObject.layer = 0;

    }

}
