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


    
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        a = FallTrap.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            
            Water.SetActive(true);
            a.Play("Flood(Trap)");
            Rain.SetActive(true);
            Platforms.SetActive(true);
            sp.sprite = open_lever;
           
        }
    }
    private void Update()
    {
        if (re.recoverRockTrap )
        {
            Water.SetActive(false);
            a.Play("Default");
            //FallTrap.SetActive(false);
            Rain.SetActive(false);
            Platforms.SetActive(false);
            sp.sprite = close_lever;
            re.recoverRockTrap = false;
        }
    }

}
