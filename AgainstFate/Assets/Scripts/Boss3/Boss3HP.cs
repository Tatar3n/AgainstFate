using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3HP : MonoBehaviour
{
    [SerializeField] private float hp = 45;
    private Boss3BehaviorScenarioUpdate enemyLogic;
    private SpriteRenderer spriteRenderer;
    public GameObject enemydeathanim;

    private void Start()
    {
        enemyLogic = GetComponent<Boss3BehaviorScenarioUpdate>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public float GetHP()
    {
        return hp;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        spriteRenderer.color = Color.red;
        Invoke("White", .2f);

        if (hp <= 0)
        {
            spriteRenderer.enabled = false;
            enemyLogic.StopAllCoroutines();
            enemyLogic.enabled = false;
            enemydeathanim.SetActive(true);
            StartCoroutine(Death());
        }

    }
    IEnumerator Death()
    {

        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);


    }
    
    public void White()
    {
        spriteRenderer.color = Color.white;
    }
}
