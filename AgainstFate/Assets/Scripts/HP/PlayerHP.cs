using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    public Slider slider;
    public void SetHealth(float nowHP)//���������� ������� ��������
    {
        slider.value = nowHP;
    }
    public void SetMaxHealth(float maxHP)//���������� ������� ��������
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }
}
