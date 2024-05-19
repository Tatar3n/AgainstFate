using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBossFight : MonoBehaviour
{
	[SerializeField] private Transform cameraMovingPoint;
	[SerializeField] private CameraMotor cameraMotor;
	[SerializeField] private GameObject bigBulletAbuDabi;
	[SerializeField] private GameObject scenario;
	private GameObject player;
	private bool isStart = false;

	private void Update()
	{
		if (isStart)
		{
			// Активация диалога
			//
			// if (dialogEnd)
			cameraMovingPoint.position = new Vector3(player.transform.position.x, cameraMovingPoint.position.y);
			cameraMotor.target = cameraMovingPoint;
			bigBulletAbuDabi.SetActive(true);
			scenario.SetActive(true);
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			player = collision.gameObject;
			isStart = true;
		}

	}
}
