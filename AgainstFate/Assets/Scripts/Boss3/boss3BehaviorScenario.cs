using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3BehaviorScenario : MonoBehaviour
{
	// состояние босса (STAY - неактивен, HORNATTACK - атака рогами до стены, THROWROCK - бросок камня в игрока)
	private enum Status
	{
		STAY = 0,
		READY = 1,
		PASSIVEATTACK = 2,
	}

	[SerializeField] private Status status = Status.PASSIVEATTACK; // текущее состояние босса
	public Boss2HP hp; // здоровье босса
	[SerializeField] private float damage;
	[SerializeField] private Transform[] spawnPoints;
	private int lastSpawnPointIndex;
	private bool canPassiveAttack;

	public Vector2 attackSize = new Vector2(2f, 2f); // Размер области атаки
	public float attackDistance = 1f; // Дистанция атаки
	public LayerMask playerLayer; // Слой игрока


	private void Start()
	{
		lastSpawnPointIndex = -1;
		canPassiveAttack = true;
	}

	private void FixedUpdate()
	{
		if (status == Status.PASSIVEATTACK)
		{
			PassiveAttack();
		}
	}

	/// /////////////////

	private void PassiveAttack()
	{
		if (canPassiveAttack)
		{
			while (true)
			{
				int ind = (int)Random.Range(0, spawnPoints.Length);
				if (ind != lastSpawnPointIndex)
				{
					lastSpawnPointIndex = ind;
					break;
				}
			}
			transform.position = spawnPoints[lastSpawnPointIndex].position;

			StartCoroutine(AttackWithDelay());

			StartCoroutine(WaterAttackDelay());
		}
	}
	private IEnumerator AttackWithDelay()
	{
		Vector3 actualPos = transform.position;
		for (int i = 1; i < 4; i++)
		{
			actualPos.x += i * 0.32f;
			Attack(actualPos, 1);

			yield return new WaitForSeconds(0.3f); 
		}
	}

	IEnumerator WaterAttackDelay()
	{
		canPassiveAttack = false;
		yield return new WaitForSeconds(10f);
		canPassiveAttack = true;
	}

	private void Attack(Vector3 position, int direction)
	{
		Vector3 dir = direction == -1 ? -transform.right : transform.right;
		Vector2 center = position + dir * attackDistance / 2;

		// Выполняем SquareCast
		RaycastHit2D hit = Physics2D.BoxCast(center, attackSize, 0f, dir, attackDistance, playerLayer);

		if (hit.collider != null)
		{
			// Попадание!
			Debug.Log("Игрок получил урон!");
		}
	}

	/// /////////

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Vector2 center = transform.position + transform.right * attackDistance / 2;

		Gizmos.DrawWireCube(center, attackSize);

		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + transform.right * attackDistance);
	}
}
