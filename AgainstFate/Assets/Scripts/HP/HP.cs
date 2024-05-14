using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float maxHP;
    private float nowHP;

    public UnityEvent death;
    public UnityEvent<float,float> damaging;
    private SpriteRenderer spriteRenderer;
    public PlayerHP playerHP;
    public Sprite[] heartimages;
    public GameObject heart;
    private Image heartimage;
    private int i = 0;
   
    private void Start()
    {
        heartimage = heart.GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Recovery();
        
    }
    public void Damaging(float value)
    {
        nowHP -= value;
        spriteRenderer.color = Color.red;

        if(nowHP<=0)
        {
            i = (i + 1) % 3;
            heartimage.sprite = heartimages[i];
           
            nowHP = 0;
            death.Invoke();
            White();
           
        }
       
        else
        {
            damaging.Invoke(maxHP, nowHP);
            playerHP.SetHealth(nowHP);
            Invoke("White", .2f);

        }


    }
    public void White()
    {
        spriteRenderer.color = Color.white;
    }

    public void Recovery()//метод восстановления HP
    {
        
        nowHP = maxHP;
        playerHP.SetMaxHealth(nowHP);
    }
   
   
}
