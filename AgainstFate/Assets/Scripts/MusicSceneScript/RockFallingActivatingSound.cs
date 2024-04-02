using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockFallingActivatingSound : MonoBehaviour
{
    
  
    public AdaptedPatterForCapricorn a;
    public Sounds Event;
    bool fl = true;

    void Update()
    {
        if (fl && (a.TimeToRockfall || RockTrapActivate.fl))
        {
            fl = false;
            Event.PlaySound(0, 1, false, false, 1, 1);
        }
        if (RockTrapActivate.EndRockTrap)
            enabled = false;
            //Event.PlaySound(1, 1, false, false, 1, 1);
    }



}

