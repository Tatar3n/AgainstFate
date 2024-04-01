using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCalfAttack : MonoBehaviour
{
    public BoxCollider2D bx;
    public bossBehaviorScenario calf;
    public Boss2HP bh;
    public GameObject trap;
    public GameObject CalfHP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(start_calf());
            trap.SetActive(true);

        }
    }
    IEnumerator start_calf()
    {
        calf.enabled = true;
        CalfHP.SetActive(true);
        bh.enabled = true;
        yield return new WaitForSeconds(2);
        bx.enabled = false;

    }
}
