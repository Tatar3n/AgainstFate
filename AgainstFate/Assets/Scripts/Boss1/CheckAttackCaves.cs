using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckAttackCaves : MonoBehaviour
{
    public UnityAction<GameObject> check;
    public Transform parent;
    private bool isAttack;
    private int countDead;
    public bool isEnd;

	private void Start()
	{
        isEnd = false;
	}

	private void Update()
	{
        if (!isEnd)
        {
            ForeachToAllChild(parent, (Transform child) =>
            {
                if (child.GetComponent<CaveThrowBullet>().isDead)
                    countDead++;

                if (!isAttack && !child.GetComponent<CaveThrowBullet>().isDead)
                    isAttack = child.GetComponent<CaveThrowBullet>().IsAttack();
                Debug.Log(countDead);
                if (countDead == 6)
                    isEnd = true;
            });
            countDead = 0;
            if (!isAttack)
                ForeachToAllChild(parent, (Transform child) =>
                {
                    if (!isAttack && !child.GetComponent<CaveThrowBullet>().isDead)
                    {
                        isAttack = true;
                        child.GetComponent<CaveThrowBullet>().isAttack = true;
                    }
                });
            isAttack = false;
        }
	}

    private void ForeachToAllChild(Transform parent, UnityAction<Transform> action)
    {
        foreach (Transform child in parent)
        {
            action(child);
            //if (child.childCount > 0)
              //  ForeachToAllChild(child, action);
        }
    }
}


