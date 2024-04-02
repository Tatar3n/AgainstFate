using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayAfterCalfDeathActivate : MonoBehaviour
{
    public GameObject HideWay;
    public Pattern p;
    public GameObject platforms;
    public PlayerMovement player;
    public GameObject CalfHp;

    private bool fl = true;
    private void Update()
    {
        if(fl && p.IsEnd)
        {
            fl = false;
            HideWay.SetActive(true);
            platforms.SetActive(true);
            player.jumpForce = 5;
            CalfHp.SetActive(false);
        }
    }
}