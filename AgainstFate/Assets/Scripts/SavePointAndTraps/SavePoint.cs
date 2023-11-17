using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SetActiveSavePoint(false);
    }

    public void SetActiveSavePoint(bool value)
    {
        animator.SetBool("IsActivate", value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Respawn respawn = collision.gameObject.GetComponent<Respawn>();

            if (respawn.savepoint == this)
                return;
            respawn.savepoint.SetActiveSavePoint(false);
            SetActiveSavePoint(true);
            respawn.savepoint = this;
        }
    }
}
