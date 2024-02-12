using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public SavePoint savepoint;
    public bool recoverRockTrap = false;

    private void Start()
    {
       savepoint.SetActiveSavePoint(true);
    }

    public void RespawnPlayer()
    {
       
        transform.position = savepoint.transform.position;
        recoverRockTrap = true;

    }
}
