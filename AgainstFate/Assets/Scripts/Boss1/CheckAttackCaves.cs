using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckAttackCaves : MonoBehaviour
{
    public UnityAction<GameObject> check;
    public Transform parent;
    private bool isAttack;

	private void Update()
	{
        ForeachToAllChild(parent, (Transform child) =>
        {
            if (!isAttack && !child.GetComponent<CaveThrowBullet>().isDead)
                isAttack = child.GetComponent<CaveThrowBullet>().IsAttack();
        });
        if(!isAttack)
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


