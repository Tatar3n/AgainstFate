using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint_RockTrap : MonoBehaviour
{
	public float speed;
	
	private void FixedUpdate()
	{
		
			gameObject.transform.position += new Vector3(0, -speed);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

		
	}
	

}
