using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BehaviorScenarioUpdate : MonoBehaviour
{
    [SerializeField] private Transform geysers;
	[SerializeField] private Transform player;
	[SerializeField] private Boss3HP bossHP;
	[SerializeField] private Transform leftEdge;
	[SerializeField] private Transform rightEdge;
	private int stage = 0;

	[SerializeField] private float speed = 2.0f; 
	[SerializeField] private float frequency = 2.0f; 
	[SerializeField] private float magnitude = 0.64f; 
	private Vector3 axis;
	private Vector3 pos;
	private bool reverseDirection = false;

	// методы атаки гейзерами
	private Transform[] geysersArr;
	private bool isStartBigGeyserAttack = false;
	private bool isGeyserPreparationEnd = false;
	private bool isGeyserAttackEnd = false;
	private bool isGeyserPreparationDelayStart = false;
	private bool isGeyserAttackDelayStart = false;
	private int middleGeyserInd = 0;
	private Transform[] fiveGeysersArr;
	private int numOfAttack;
	// 
	private bool isAttackStart = false;
	//
	private List<Transform> randomGaysers;
	private bool isRandomGeyserAttackStart = false;
	private int cntOfAttack = 0;
	private bool isIntervalAttacksDelayEnd = true;

	[SerializeField] private Transform FirstPlatforms;

	private void Start()
	{
		geysersArr = new Transform[geysers.childCount];
		int i = 0;
		foreach (Transform geyser in geysers)
		{
			geysersArr[i] = geyser;
			i++;
		}

		randomGaysers = new List<Transform>();

		pos = transform.position;
		axis = transform.up;

		bossHP = GetComponent<Boss3HP>();
	}

	private bool isBossInCentre = false;

	private void Update()
	{
		if (stage == 0)
		{
			GeysersAttack();
			if (cntOfAttack > 5)
			{
				if (!isBossInCentre)
				{
					transform.position = new Vector3(geysersArr[20].position.x, geysersArr[20].position.y + 1.6f);
					// анимация появления
					pos = transform.position;
					isBossInCentre = true;
				}

				MoveBoss();

				if (bossHP.GetHP() == 30)
				{
					isStartBigGeyserAttack = false;
					isGeyserPreparationEnd = false;
					isGeyserAttackEnd = false;
					isGeyserPreparationDelayStart = false;
					isGeyserAttackDelayStart = false;
					middleGeyserInd = 0;
					isAttackStart = false;

					// анимация исчезновения
					gameObject.transform.position = new Vector3(-50f, -50f);
					stage++;
				}
			}
		}
		else if (stage == 1)
		{
			// активация воды
			FirstPlatforms.gameObject.SetActive(true);
		}
	}

	// методы атаки гейзерами
	private void GeysersAttack()
	{
		if (!isAttackStart)
			numOfAttack = (int)Random.Range(0, 2);
		if (isIntervalAttacksDelayEnd)
		{
			if (numOfAttack == 0)
			{
				if (!isStartBigGeyserAttack)
				{
					isAttackStart = true;
					cntOfAttack++;

					for (int i = 0; i < geysersArr.Length; i++)
					{
						if (Mathf.Abs(geysersArr[i].position.x - player.position.x) < 0.16f)
						{
							middleGeyserInd = i;
							break;
						}
					}
					fiveGeysersArr = Find5Geysers(middleGeyserInd);
					isStartBigGeyserAttack = true;
				}
				else
				{
					if (!isGeyserPreparationEnd)
					{
						foreach (Transform geiser in fiveGeysersArr)
							geiser.GetComponent<ChangeSpriteGeyser>().activateSmallGeyserSprite();
						if (!isGeyserPreparationDelayStart)
							StartCoroutine(GeyserPreparationDelay());
					}
					else if (!isGeyserAttackEnd)
					{
						foreach (Transform geiser in fiveGeysersArr)
						{
							geiser.GetComponent<ChangeSpriteGeyser>().activateBigGeyserSprite();
							geiser.GetComponent<BoxCollider2D>().enabled = true;
						}
						if (!isGeyserAttackDelayStart)
							StartCoroutine(GeyserAttackDelay());
					}
					else if (isGeyserAttackEnd && isGeyserPreparationEnd)
					{
						foreach (Transform geiser in fiveGeysersArr)
						{
							geiser.GetComponent<ChangeSpriteGeyser>().DeactivateSprite();
							geiser.GetComponent<BoxCollider2D>().enabled = false;
						}
						isStartBigGeyserAttack = false;
						isGeyserPreparationEnd = false;
						isGeyserAttackEnd = false;
						isGeyserPreparationDelayStart = false;
						isGeyserAttackDelayStart = false;
						middleGeyserInd = 0;
						isAttackStart = false;
						StartCoroutine(IntervalAttacksDelay());
					}
				}
			}
			else if (numOfAttack == 1)
			{
				if (!isRandomGeyserAttackStart)
				{
					isAttackStart = true;
					cntOfAttack++;
					while (true)
					{
						int geyserInd = Random.Range(0, geysersArr.Length);

						if (!randomGaysers.Contains(geysersArr[geyserInd]) &&
							!(geyserInd > 0 && geyserInd < geysersArr.Length - 1 &&
							randomGaysers.Contains(geysersArr[geyserInd - 1]) &&
							randomGaysers.Contains(geysersArr[geyserInd + 1])))
						{
							randomGaysers.Add(geysersArr[geyserInd]);
						}
						if (randomGaysers.Count == 20)
							break;
					}
					isRandomGeyserAttackStart = true;
				}
				else if (!isGeyserPreparationEnd)
				{
					foreach (Transform geiser in randomGaysers)
						geiser.GetComponent<ChangeSpriteGeyser>().activateSmallGeyserSprite();
					if (!isGeyserPreparationDelayStart)
						StartCoroutine(GeyserPreparationDelay());
				}
				else if (!isGeyserAttackEnd)
				{
					foreach (Transform geiser in randomGaysers)
					{
						geiser.GetComponent<ChangeSpriteGeyser>().activateBigGeyserSprite();
						geiser.GetComponent<BoxCollider2D>().enabled = true;
					}
					if (!isGeyserAttackDelayStart)
						StartCoroutine(GeyserAttackDelay());
				}
				else if (isGeyserAttackEnd && isGeyserPreparationEnd)
				{
					foreach (Transform geiser in randomGaysers)
					{
						geiser.GetComponent<ChangeSpriteGeyser>().DeactivateSprite();
						geiser.GetComponent<BoxCollider2D>().enabled = false;
					}
					isRandomGeyserAttackStart = false;
					isGeyserPreparationEnd = false;
					isGeyserAttackEnd = false;
					isGeyserPreparationDelayStart = false;
					isGeyserAttackDelayStart = false;
					randomGaysers.Clear();
					isAttackStart = false;
					StartCoroutine(IntervalAttacksDelay());
				}
			}

		}
	}

	private Transform[] Find5Geysers(int middleGeyserInd)
	{
		Transform[] res = new Transform[5];

		for (int i = 0; i < 5; i++)
		{
			int newIndex = middleGeyserInd - 2 + i;
			if (newIndex < 0)
			{
				newIndex = middleGeyserInd + 3 + (i+1)/2;
			}
			else if (newIndex >= geysersArr.Length)
			{
				newIndex = middleGeyserInd - 3 - (5-i)/2;
			}
			res[i] = geysersArr[newIndex];
		}
		return res;
	}

	private IEnumerator GeyserPreparationDelay()
	{
		isGeyserPreparationDelayStart = true;
		isGeyserPreparationEnd = false;
		yield return new WaitForSeconds(1.5f);
		isGeyserPreparationEnd = true;
	}

	private IEnumerator GeyserAttackDelay()
	{
		isGeyserAttackDelayStart = true;
		isGeyserAttackEnd = false;
		yield return new WaitForSeconds(1f);
		isGeyserAttackEnd = true;
	}

	private IEnumerator IntervalAttacksDelay()
	{
		isIntervalAttacksDelayEnd = false;
		yield return new WaitForSeconds(0.7f);
		isIntervalAttacksDelayEnd = true;
	}
	// конец методов атаки гейзерами


	// Общие методы
	private void MoveBoss()
	{
		if (!reverseDirection)
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		else
			transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		pos += transform.right * Time.deltaTime * speed;
		transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; 
		if (pos.x >= rightEdge.position.x)
			reverseDirection = true; 
		else if (pos.x <= leftEdge.position.x)
			reverseDirection = false; 
	}
	// конец общих методов
}
