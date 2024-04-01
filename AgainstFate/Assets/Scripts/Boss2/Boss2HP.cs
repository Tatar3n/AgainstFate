using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HP : MonoBehaviour
{
    [SerializeField] private float hp = 1000;
    private SpriteRenderer spriteRenderer;
    private bossBehaviorScenario enemyLogic;
    public GameObject EndDialog;
    public PlayerHP ph;
    public GameObject enemydeathanim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyLogic = GetComponent<bossBehaviorScenario>();
    }

    public float GetHP()
    {
        return hp;
    }

    void Update()
    {
      
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        spriteRenderer.color = Color.red;
        Invoke("White", .2f);
        ph.SetHealth(hp);

        if (hp <= 0)
        {
            EndDialog.SetActive(true);
            spriteRenderer.enabled = false;
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
