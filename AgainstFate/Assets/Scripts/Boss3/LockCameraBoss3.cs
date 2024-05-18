using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraBoss3 : MonoBehaviour
{
	[SerializeField] private CameraMotor mainCamera;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			mainCamera.lockCameraY = true;
			Destroy(gameObject);
		}
	}
}
