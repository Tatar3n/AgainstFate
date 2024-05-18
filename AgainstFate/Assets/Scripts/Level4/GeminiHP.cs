using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GeminiHP : MonoBehaviour
{
    public Image fillimage;
    [SerializeField] private float hp = 100;
    public UnityEvent death;
    private SpriteRenderer spriteRenderer;
    private GeminiAttackLogic enemyLogic;
    public GameObject enemydeathanim;
    public bool IsDead = false;
    public GameObject hpbar;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyLogic = GetComponent<GeminiAttackLogic>();
    }
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            spriteRenderer.enabled = false;
            enemyLogic.StopAllCoroutines();
            enemydeathanim.SetActive(true);
            hpbar.SetActive(false);
            StartCoroutine(Death());
        }
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        fillimage.fillAmount = hp*0.01f;
        spriteRenderer.color = Color.red;
        Invoke("White", .2f);
    }
    IEnumerator Death()
    {
        IsDead = true;
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);


    }
    public void White()
    {
        spriteRenderer.color = Color.white;
    }
}
