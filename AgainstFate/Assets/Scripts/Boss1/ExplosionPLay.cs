using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPLay : MonoBehaviour
{
    public PlayerMovement player;
    public ParticleSystem expl;
    public Pattern p;
    private bool fl = true;
    public GameObject scorp;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && fl)
        {
            if (p.IsEnd)
            {
                expl.Play();
                fl = false;
                scorp.SetActive(false);
            }
        }
    }
}
