using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{
	[SerializeField] private GameObject obj;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Закрыли пол");
		obj.GetComponent<BoxCollider2D>().enabled = true;
	}
}
