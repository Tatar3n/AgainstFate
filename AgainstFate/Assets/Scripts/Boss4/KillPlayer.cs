using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

	private void Update()
	{
		if (transform.position.x > player.position.x)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
