using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFallingAfterKillCave : MonoBehaviour
{
    private float updateTime;
    public float timeToNext;
    public bool flag;
    public Transform[] fallPoints;
    private int actualFall;
    public GameObject rock;

	private void Start()
	{
        updateTime = timeToNext;
        flag = false;
        actualFall = 0;
	}

	public void Update()
    {
        flag = actualFall == fallPoints.Length;

        if (gameObject.GetComponent<CaveThrowBullet>().isDead && !flag)
        {
            updateTime -= Time.deltaTime;
            if (updateTime < 0)
            {
                Instantiate(rock, fallPoints[actualFall]);
                updateTime = timeToNext;
                actualFall++;
            }
        }
    }
}
