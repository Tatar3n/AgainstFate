using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFalling : MonoBehaviour
{
	public float speed;

	private void Update()
	{
		gameObject.transform.position += new Vector3(0, -speed);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
	}
}
