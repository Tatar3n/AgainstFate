using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWayPointController : MonoBehaviour
{
    public bool jumpOnLeft = false;
    public bool jumpOnRight = false;

    public bool IsJump(float speed)
    {
        return (jumpOnLeft && speed < 0) || (jumpOnRight && speed > 0);
    }
}
