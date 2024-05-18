using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss3 : MonoBehaviour
{
	[SerializeField] private Boss3BehaviorScenarioUpdate scenario;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// Вот сюда можно вставить диалоги

			//
			scenario.enabled = true;
			Destroy(gameObject);
		}
	}
}
