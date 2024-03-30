using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeActivate : MonoBehaviour
{
    public AdaptedPatterForCapricorn a;
   
    void Update()
    {
        if (a.TimeToRockfall || RockTrapActivate.fl)
            CameraShake.startshake = true;
        if(RockTrapActivate.EndRockTrap)
            CameraShake.startshake = false;
    }
   
}
