using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boss3BehaviorScenarioUpdate : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Boss3HP bossHP;
	[SerializeField] private Transform leftEdge;
	[SerializeField] private Transform rightEdge;
	public GameObject water;
	public int stage = 0;

	[SerializeField] private float speed = 2.0f; 
	[SerializeField] private float frequency = 2.0f; 
	[SerializeField] private float magnitude = 0.64f; 
	private Vector3 axis;
	private Vector3 pos;
	private bool reverseDirection = false;

	// методы атаки гейзерами
	[SerializeField] private Transform movePointGeysers;
	[SerializeField] private Transform geysers;
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

	private bool isBossInCentre = false;

	public float radius = 2f; // Радиус орбиты
	public float bulletSpeed = 5f; // Скорость вращения
	private List<Transform> bullets3;
	[SerializeField] GameObject bullet;
	private bool isBulletCreate = false;
	[SerializeField] private Transform[] startBulletsLocations;
	private List<Transform> bullets5;
	[SerializeField] private Transform[] bullet5Directions;
	private bool isBetweenBulletsRangeAttackEnd = true;
	private int cntOfRangeAttack = 0;
	private bool isStartBulletAttack = false;
	private int ChooseBulletAttack = 0;
	private bool isIntervalBulletsAttackEnd = true;
	private bool canThrowBullet = false;
	private int cntShoots = 0;

	private bool isBossDownDelayEnd = false;

	[SerializeField] private Transform lastPlatform;
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

		bullets3 = new List<Transform>();
		bullets5 = new List<Transform>();
	}

	private int cntOfBulletAttacks = 0;
	[SerializeField] private Transform downPoint;
	private float lastHP;
	private bool isBossDownDelayStart = false;
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

				if (bossHP.GetHP() == 40)
				{
					DeactivateGeyserAttack();

					// анимация исчезновения
					gameObject.transform.position = new Vector3(-50f, -50f);
					isBossInCentre = false;
					stage++;
				}
			}
		}
		else if (stage == 1)
		{
			// активация воды
			FirstPlatforms.gameObject.SetActive(true);
			geysers.position = movePointGeysers.position;
			transform.position = new Vector3(geysersArr[20].position.x, geysersArr[20].position.y + 2.88f);
			DeactivateGeyserAttack();
		}
		else if (stage == 2)
		{
			GeysersAttack();

			if (cntOfBulletAttacks < 4)
			{
				if (!isStartBulletAttack)
				{
					ChooseBulletAttack = (int)Random.Range(0, 2);
				}
				if (isIntervalBulletsAttackEnd)
				{
					if (ChooseBulletAttack == 0)
						Throw3Bullets();
					else
						RoundBulletAttack();
				}
				isBossDownDelayEnd = false;
				lastHP = bossHP.GetHP();
			}
			else
			{
				if (!isBossDownDelayEnd)
				{
					if (downPoint.position.y < transform.position.y)
					{
						transform.position += -transform.up * Time.deltaTime * 0.64f;
					}
					else if (!isBossDownDelayStart)
					{
						isBossDownDelayStart = true;
						StartCoroutine(BossDownDelay());
					}
				}

				if (isBossDownDelayEnd || bossHP.GetHP() < lastHP)
				{
					if (new Vector3(geysersArr[20].position.x, geysersArr[20].position.y + 2.88f).y > transform.position.y)
						transform.position += transform.up * Time.deltaTime * 2f;
					else
					{
						isBossDownDelayEnd = false;
						isBossDownDelayStart = false;
						cntOfBulletAttacks = 0;
					}
				}
			}
		}
	}

	private IEnumerator BossDownDelay()
	{
		isBossDownDelayEnd = false;
		yield return new WaitForSeconds(4f);
		isBossDownDelayEnd = true;
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
						DeactivateGeyserAttack();
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
					DeactivateGeyserAttack();
				}
			}

		}
	}

	private void DeactivateGeyserAttack()
	{
		foreach (Transform geiser in randomGaysers)
		{
			geiser.GetComponent<ChangeSpriteGeyser>().DeactivateSprite();
			geiser.GetComponent<BoxCollider2D>().enabled = false;
		}
		foreach (Transform geiser in geysersArr)
		{
			geiser.GetComponent<ChangeSpriteGeyser>().DeactivateSprite();
			geiser.GetComponent<BoxCollider2D>().enabled = false;
		}
		isRandomGeyserAttackStart = false;
		isStartBigGeyserAttack = false;
		isGeyserPreparationEnd = false;
		isGeyserAttackEnd = false;
		isGeyserPreparationDelayStart = false;
		isGeyserAttackDelayStart = false;
		randomGaysers.Clear();
		isAttackStart = false;
		StartCoroutine(IntervalAttacksDelay());
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

	// Методы атаки шарами с водой
	private void Throw3Bullets()
	{
		float angleOffset = 360f / 3f; // Расстояние между пулями

		for (int i = 0; i < bullets3.Count; i++)
		{
			Transform b = bullets3[i];
			if (b != null && !b.gameObject.GetComponent<StaticBulletController>().enabled)
			{
				float bulletAngle = Time.time * bulletSpeed + i * angleOffset;
				float x = transform.position.x + radius * Mathf.Cos(bulletAngle * Mathf.Deg2Rad);
				float y = transform.position.y + radius * Mathf.Sin(bulletAngle * Mathf.Deg2Rad);
				Vector2 direction = (new Vector2(x, y) - (Vector2)transform.position).normalized;
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				b.position = new Vector2(x, y);
				b.rotation = Quaternion.Euler(0f, 0f, angle); 
			}
		}
		if (!isBulletCreate)
		{
			isStartBulletAttack = true;
			bullets3.Add(Instantiate(bullet, startBulletsLocations[0].position, Quaternion.identity).GetComponent<Transform>());
			bullets3.Add(Instantiate(bullet, startBulletsLocations[1].position, Quaternion.identity).GetComponent<Transform>());
			bullets3.Add(Instantiate(bullet, startBulletsLocations[2].position, Quaternion.identity).GetComponent<Transform>());
			isBulletCreate = true;
			canThrowBullet = true;
			StartCoroutine(BeforeBulletsAttackDelay());
		}
		else if (canThrowBullet)
		{
			if (cntShoots < 3)
			{
				Transform bulForDel = bullets3.FirstOrDefault(b => b != null);
				if (bulForDel != null)
				{
					foreach (Transform bullet in bullets3)
					{
						if (bulForDel != null && bullet != null && bullet.position.y < bulForDel.position.y && !bullet.gameObject.GetComponent<StaticBulletController>().enabled)
							bulForDel = bullet;
					}
					bullets3[bullets3.FindIndex(s => s == bulForDel)] = null;
					bulForDel.GetComponent<StaticBulletController>().point = player.transform;
					bulForDel.GetComponent<StaticBulletController>().enabled = true;
					cntShoots++;
					StartCoroutine(IntervalBulletsDelay());
				}
			}
			else
			{
				canThrowBullet = false;
				isBulletCreate = false;
				isStartBulletAttack = false;
				cntShoots = 0;
				bullets3.Clear();
				cntOfBulletAttacks++;
				StartCoroutine(IntervalBulletsAttack());
			}
		}
	}
	private IEnumerator IntervalBulletsDelay()
	{
		canThrowBullet = false;
		yield return new WaitForSeconds(1f);
		canThrowBullet = true;
	}

	private IEnumerator BeforeBulletsAttackDelay()
	{
		canThrowBullet = false;
		yield return new WaitForSeconds(2f);
		canThrowBullet = true;
	}

	private void RoundBulletAttack()
	{

		if (isBetweenBulletsRangeAttackEnd && cntOfRangeAttack < 5)
		{
			isStartBulletAttack = true;
			for (int i = 3; i < startBulletsLocations.Length; i++)
				bullets5.Add(Instantiate(bullet, startBulletsLocations[i].position, Quaternion.identity).GetComponent<Transform>());
			for (int i = 0; i < bullets5.Count; i++)
			{
				Vector2 offset = Random.insideUnitCircle * 0.04f;
				bullets5[i].GetComponent<StaticBulletController>().point = bullet5Directions[i];
				bullets5[i].GetComponent<StaticBulletController>().point.position = new Vector3(bullet5Directions[i].position.x + offset.x, bullet5Directions[i].position.y + offset.y);
				bullets5[i].GetComponent<StaticBulletController>().speed = 2f;
				bullets5[i].GetComponent<StaticBulletController>().enabled = true;
			}
			cntOfRangeAttack++;
			bullets5.Clear();
			StartCoroutine(IntervalBetweenBulletsRangeAttack());
		}
		else if (cntOfRangeAttack >= 5)
		{
			cntOfRangeAttack = 0;
			isStartBulletAttack = false;
			cntOfBulletAttacks++;
			StartCoroutine(IntervalBulletsAttack());
		}


	}

	private IEnumerator IntervalBulletsAttack()
	{
		isIntervalBulletsAttackEnd = false;
		yield return new WaitForSeconds(0.7f);
		isIntervalBulletsAttackEnd = true;
	}

	private IEnumerator IntervalBetweenBulletsRangeAttack()
	{
		isBetweenBulletsRangeAttackEnd = false;
		yield return new WaitForSeconds(1f);
		isBetweenBulletsRangeAttackEnd = true;
	}

	// конец методов атаки водой

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

	private void OnDestroy()
	{
		StopAllCoroutines();
		DeactivateGeyserAttack();
		// активация воды
		//lastPlatform.gameObject.transform.position = new Vector3(player.position.x, lastPlatform.gameObject.transform.position.y, player.position.z);
		//lastPlatform.gameObject.SetActive(true);
		//water.SetActive(true);
	}
}
