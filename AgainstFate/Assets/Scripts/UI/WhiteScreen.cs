using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteScreen : MonoBehaviour
{
    public float fadespeed = 1f;
    

    IEnumerator Start()
    {
        Image fade = GetComponent<Image>();
        Color color = fade.color;

        while (color.a > 0f)
        {
            color.a -= fadespeed * Time.deltaTime;
            fade.color = color;
            yield return null;
        }
    }
}
