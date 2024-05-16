using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform whereTeleport;
	[SerializeField] private Transform player;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player_Fireball"))
		{
			player.position = whereTeleport.position;
		}
	}
}
