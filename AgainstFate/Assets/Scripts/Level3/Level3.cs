using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject Water;
    public GameObject FallTrap;
    public GameObject Rain;
    public GameObject Platforms;
    SpriteRenderer sp;
    public Sprite open_lever;
    public Sprite close_lever;
    public Respawn re;
    bool fl = false;
    Animator a;
    Animator water;

    
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        a = FallTrap.GetComponent<Animator>();
        water = Water.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && (Input.GetKeyDown(KeyCode.E) || fl))
        {

            water.Play("Flood");
            a.Play("Flood(Trap)");
            Rain.SetActive(true);
            Platforms.SetActive(true);
            sp.sprite = open_lever;
            fl = true;
           
        }
        
    }
    private void Update()
    {
        if (re.recoverRockTrap )
        {
            water.Play("WaterDefault");
            a.Play("Default");
            //FallTrap.SetActive(false);    
            
            re.recoverRockTrap = false;
        }
    }

}
