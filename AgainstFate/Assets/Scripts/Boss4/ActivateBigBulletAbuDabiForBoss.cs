using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBigBulletAbuDabiForBoss : MonoBehaviour
{
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject portal;

	private void Update()
	{
		if (GetComponent<LeverController>()._fall)
		{
			bullet.SetActive(true);
			portal.SetActive(true);
			Destroy(gameObject);
		}
	}
}
