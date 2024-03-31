using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    public PlayerMovement player;
    public AdaptedPatterForCapricorn a;
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player.IsGrounded() && !a.IsEnd)
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
