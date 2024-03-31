using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHP1 : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    public UnityEvent death;
    private SpriteRenderer spriteRenderer;
    public  GameObject enemydeathanim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
        void FixedUpdate()
        {
        if (hp <= 0)
        {
            spriteRenderer.enabled = false;
            enemydeathanim.SetActive(true);
            StartCoroutine(Death());
        }
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        spriteRenderer.color = Color.red;
            Invoke("White", .2f);

        


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

