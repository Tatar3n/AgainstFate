using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopforPattern : MonoBehaviour
{
    public PlayerMovement player;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.IsGrounded() && !Pattern.IsEnd)
            {
                player.isDialog = true;
                player.isFreezing = true;
              
                
            }

            else
            {
                player.isDialog = false;
                player.isFreezing = false;
            }
        }
    }
}
