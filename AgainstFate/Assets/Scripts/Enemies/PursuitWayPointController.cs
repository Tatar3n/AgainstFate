using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitWayPointController : PatrolWayPointController
{
    public enum Wh
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public Transform[] connectedPoints;
}
