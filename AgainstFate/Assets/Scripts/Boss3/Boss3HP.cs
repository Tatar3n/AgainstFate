using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3HP : MonoBehaviour
{
    [SerializeField] private float hp = 45;
    private Boss3BehaviorScenarioUpdate enemyLogic;

    private void Start()
    {
        enemyLogic = GetComponent<Boss3BehaviorScenarioUpdate>();
    }

    public float GetHP()
    {
        return hp;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            enemyLogic.enabled = false;
            StartCoroutine(Death());
        }

    }
    IEnumerator Death()
    {

        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);


    }
}
