using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

	private void Update()
	{
		if (transform.position.x > player.position.x)
		{
			player.gameObject.GetComponent<HP>().Damaging(5000f);
		}
	}
}
