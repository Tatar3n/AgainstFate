using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToLift : MonoBehaviour
{
    public GameObject EndLevelPlatforms;

	private void Update()
	{
		if(gameObject.GetComponent<CheckAttackCaves>().isEnd)
			EndLevelPlatforms.SetActive(true);
	}
}
