using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserGiveDamage : MonoBehaviour
{
	[SerializeField] private float damage = 0.2f;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<HP>().Damaging(damage);
		}
	}
}
