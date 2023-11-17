using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float maxHP;
    private float nowHP;

    public UnityEvent death;
    public UnityEvent<float, float> damaging;

    
    private void Start()
    {
        Recovery();
        
    }
    public void Damaging(float value)
    {
        nowHP -= value;

        if (nowHP <= 0)
        {
            nowHP = 0;
            death.Invoke();
        }
        damaging.Invoke(maxHP, nowHP);
       
    }

    public void Recovery()//метод восстановления HP
    {
        nowHP = maxHP;

    }


}
