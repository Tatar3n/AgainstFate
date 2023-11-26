using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
	[SerializeField] private GameObject obj;

	public void Activate()
	{
		obj.SetActive(false);
	}
	
}
