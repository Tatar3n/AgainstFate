using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCaves : MonoBehaviour
{
	public GameObject caves;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		caves.SetActive(true);
	}
}
