using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCage : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    private float timeToActivate;

    void Start()
    {
        timeToActivate = 1f;
    }

    void Update()
    {
        if (gameObject.GetComponent<CheckAttackCaves>().timerBetweenAttacks != 6.5f && !gameObject.GetComponent<CheckAttackCaves>().isEnd)
        {
            timeToActivate -= Time.deltaTime;
            if (timeToActivate < 0)
            {
                wall1.SetActive(true);
                wall2.SetActive(true);
                timeToActivate = 1f;
            }

        }
        else
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
        }
    }
}
