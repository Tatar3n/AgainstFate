using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject Water;
    public GameObject FallTrap;
    public GameObject Rain;
    public GameObject Platforms;
    public Respawn re;
    Animator a;
    Animator water;

    public GameObject[] movingplatforms;
    private MovingPlatformUpDown[] movingscripts;
    private Vector3[] start_position;

    
    private void Start()
    {
        movingscripts = new MovingPlatformUpDown[movingplatforms.Length];
        start_position = new Vector3[movingplatforms.Length];
        for (int i = 0; i < movingplatforms.Length;++i)
        {
            var tr = movingplatforms[i].GetComponent<Transform>().position;
            movingscripts[i] = movingplatforms[i].GetComponent<MovingPlatformUpDown>();
            start_position[i] = new Vector3(tr.x,tr.y,tr.z);
        }
        a = FallTrap.GetComponent<Animator>();
        water = Water.GetComponent<Animator>();
    }    
  
    private void Update()
    {
      
            water.Play("Flood");
            a.Play("Flood(Trap)");
            Rain.SetActive(true);
            Platforms.SetActive(true);
         
        if (re.recoverRockTrap )
        {
            for (int i = 0; i < movingplatforms.Length; i++)
            {
                movingplatforms[i].transform.position = start_position[i];
                movingscripts[i].enabled = false;
            }
            water.Play("WaterDefault");
            a.Play("Default");
            //FallTrap.SetActive(false);    
            
            re.recoverRockTrap = false;
        }
    }

}
