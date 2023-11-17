using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public Slider slider;
    public void SetHealth(float nowHP)//перемещает слайдер здоровья
    {
        slider.value = nowHP;
    }
    public void SetMaxHealth(float maxHP)//перемещает слайдер здоровья
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }
}
