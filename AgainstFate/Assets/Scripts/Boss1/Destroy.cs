using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	[SerializeField] private GameObject obj;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Уничтожен объект:" + obj.name);
		Destroy(obj);
	}
}
