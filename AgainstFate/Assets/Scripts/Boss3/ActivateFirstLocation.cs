using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFirstLocation : MonoBehaviour
{
    [SerializeField] private Transform Bullets;
	[SerializeField] private Transform bridge;
	private bool isNextBulletDelayEnd = true;
	private bool start = false;

	private void Update()
	{
		BulletAttack();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			bridge.gameObject.SetActive(true);
			start = true;
		}
	}

	private void BulletAttack()
	{
		if (start)
		{
			if (Bullets.childCount == 0)
				Destroy(gameObject);
			foreach (Transform Bullet in Bullets)
			{
				if (isNextBulletDelayEnd)
				{
					Bullet.gameObject.GetComponent<StaticBulletController>().enabled = true;
					StartCoroutine(NextBulletDelay());
				}
			}
		}
	}

	private IEnumerator NextBulletDelay()
	{
		isNextBulletDelayEnd = false;
		yield return new WaitForSeconds(0.1f);
		isNextBulletDelayEnd = true;
	}
}
