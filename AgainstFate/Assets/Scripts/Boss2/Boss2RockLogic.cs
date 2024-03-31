using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2RockLogic : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.layer == 3)
		{
			Debug.Log("Камень попал");
			collision.gameObject.GetComponent<HP>().Damaging(30);
		}
		else if(collision.gameObject.layer == 6)
			Destroy(gameObject);
	}
}
