using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
	[SerializeField] private GameObject obj;

	private void OnCollisionEnter2D(Collision2D collision)
	{
			obj.SetActive(false);
	}
}
