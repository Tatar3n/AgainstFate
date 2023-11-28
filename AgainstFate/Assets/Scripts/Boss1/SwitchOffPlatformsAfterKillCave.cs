using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOffPlatformsAfterKillCave : MonoBehaviour
{
    public GameObject obj;

    public void Update()
    {

        if (gameObject.GetComponent<CheckAttackCaves>().timerBetweenAttacks != 6.5f && !gameObject.GetComponent<CheckAttackCaves>().isEnd)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }
}
