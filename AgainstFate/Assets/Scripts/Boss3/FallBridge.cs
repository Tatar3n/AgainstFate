using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBridge : MonoBehaviour
{
	[SerializeField] private Transform bridge;
	[SerializeField] private float shakeDelay = 3f;
	private bool isContinueShake = false;

	private void Update()
	{
		if(isContinueShake)
			CameraShake.startshake = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// В этот момент вызываются диалоги и желательно тряска

			//

			foreach (Transform child in bridge)
				child.gameObject.SetActive(false);

			isContinueShake = true;
			StartCoroutine(ShakeDelay());
		}
	}

	IEnumerator ShakeDelay()
	{
		yield return new WaitForSeconds(shakeDelay);
		CameraShake.startshake = false;
		Destroy(gameObject);
	}
}
