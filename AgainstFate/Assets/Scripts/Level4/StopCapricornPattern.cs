using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCapricornPattern : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject wall;
    bool fl = true;
    public AdaptedPatterForCapricorn p;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.IsGrounded() && !p.IsEnd)
            {
                player.isDialog = true;
                player.isFreezing = true;


            }

            else if (p.IsEnd)
            {

                player.isDialog = false;
                player.isFreezing = false;
                wall.SetActive(false);
                fl = false;
            }
        }
    }
}
