using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float maxHP;
    public float nowHP;

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

        if(nowHP<=0 && i < heartimages.Length-1)
        {
            heartimage.sprite = heartimages[i + 1];
            ++i;
            nowHP = 0;
            death.Invoke();
            White();
        }
        else if(i >= heartimages.Length-1)
        {
            i = -1;
            //restart
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
