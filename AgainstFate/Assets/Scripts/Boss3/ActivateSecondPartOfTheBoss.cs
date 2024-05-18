using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSecondPartOfTheBoss : MonoBehaviour
{
    [SerializeField] private Boss3BehaviorScenarioUpdate scenario;
	[SerializeField] private CameraMotor mainCamera;
	[SerializeField] private Transform lockTrigger;
	[SerializeField] private Transform lowerBridge;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player_Fireball"))
		{
			scenario.stage++;
			mainCamera.yOffset += 1.28f;
			lockTrigger.gameObject.SetActive(true);
			lowerBridge.gameObject.SetActive(true);
		}
	}

}
