using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{
	SpriteRenderer sp;
    public Sprite open_lever;
    public bool _fall = false;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetKeyDown(KeyCode.E))
        {
			_fall = true;
            sp.sprite = open_lever;
        }			
	}
}
