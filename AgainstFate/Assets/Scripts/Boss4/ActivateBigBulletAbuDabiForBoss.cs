using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateBigBulletAbuDabiForBoss : MonoBehaviour
{
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject portal;
	public GameObject darkscreen;
	


	private void Update()
	{
		if (GetComponent<LeverController>()._fall)
		{
			bullet.SetActive(true);
			portal.SetActive(true);
			StartCoroutine(next());
			
		}
	}
	IEnumerator next()
    {
		darkscreen.SetActive(true);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(10);
		Destroy(gameObject);

	}
}
