using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterGeminiDeath : MonoBehaviour
{
    private bool f = true;
    public GameObject g1, g2;
    public GameObject wayaftergeminideath;
    public DialogueAfterGeminiDeath d;

    // Update is called once per frame
    void Update()
    {
        if (d.IsEnd&& f && g1 == null && g2 == null)
            wayaftergeminideath.SetActive(true);

    }
}
