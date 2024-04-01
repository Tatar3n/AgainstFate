using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviorScenario : MonoBehaviour
{

	Animator a;
	public ParticleSystem expl;
	// Переменные и классы связанные с боссом

	// состояние босса (STAY - неактивен, HORNATTACK - атака рогами до стены, THROWROCK - бросок камня в игрока)
	private enum Status
	{
		STAY = 0,
		READY = 1,
		HORNATTACK = 2,
		THROWROCK = 3
	}

	[SerializeField] private Status status = Status.STAY; // текущее состояние босса
    public Boss2HP hp; // здоровье босса
	[SerializeField] private float damage;
	[SerializeField] private Transform middleOfArena;
	[SerializeField] private Transform leftEdgeOfArena;
	[SerializeField] private Transform rightEdgeOfArena;
	[SerializeField] private Transform throwPoint;
	[SerializeField] private Rigidbody2D stone;
	[SerializeField] private float throwForce = 10f;
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;
	private bool canAttackWhenBossCollision = true;

	[SerializeField] private float walkSpeed = 3;
	[SerializeField] private float runSpeed = 6;

	/////

	// Переменные и классы связанные с игроком

	[SerializeField] private Transform player; // положение игрока
	[SerializeField] private Rigidbody2D playerRb;
	[SerializeField] private LayerMask playerLayerMask;
	private HP playerHP;

	/////

	// переменные связанные с атакой рогами

	private Transform oppositeEdge; // противоположный край для атаки рогами
	private Vector2 knockbackDirection;
	[SerializeField] private float knockbackForce = 5f;
	private bool isInEdge = false;
	private bool isInWall = false; // активна, если враг ударился рогами о стену 
	private bool stayInWall = false; // активна, пока враг стоит в стене
	private bool isPlayerBoosted = false;

	/////

	// переменные связанные с этапом подготовки к атаке

	private bool isPreparationEnd = false;
	private bool isStartPreparation = false;
	private bool isJumpEnd = false;
	private bool isStop = false;

	/////

	private bool isThrowRockEnd = false;
	private bool isThrowRock = false;
	private void Start()
	{
		hp = GetComponent<Boss2HP>();
		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		playerHP = player.gameObject.GetComponent<HP>();
		a = GetComponent<Animator>();
	}

	private void PreparationToChooseAttack()
	{
		expl.Play();
		if (!isStartPreparation)
		{
			StartCoroutine(PreparationToAttackDelay());
			isStartPreparation = true;
		}
		if (transform.position.y <= player.position.y + 3.84f && !isJumpEnd)
			rb.velocity = (Vector2)(middleOfArena.position - transform.position) + Vector2.up * 10;
		else
		{
			isJumpEnd = true;
			expl.Stop();
			if (!isStop)
			{
				rb.velocity = Vector2.zero;
				isStop = true;
				transform.position = new Vector2(player.transform.position.x + Random.Range(-0.32f, 0.32f), transform.position.y);
			}
		}
	}

	IEnumerator PreparationToAttackDelay()
	{
		isPreparationEnd = false;
		yield return new WaitForSeconds(2f); // Задержка в 10 секунд
		isPreparationEnd = true;
	}

	private void FixedUpdate()
	{
		if (status != Status.STAY)
		{

			if (status == Status.READY)
			{
				
				PreparationToChooseAttack();
				if (isPreparationEnd)
				{
					isStartPreparation = false;
					isPreparationEnd = false;
					isJumpEnd = false;
					isStop = false;

					status = (Status)(int)Random.Range(2, 4);
				}
			}
			else if (status == Status.HORNATTACK)
			{
				
				HornAttack();
				
			}
			else if (status == Status.THROWROCK)
			{
				
				ThrowStone();
			}
		}
		else
		{
			a.Play("CalfDefault");
		}
		GiveDamageWhenPlayerEntersBossCollision();
		Flip();
	}

	IEnumerator ThrowRockDelay()
	{
		isThrowRockEnd = false;
		yield return new WaitForSeconds(2f); 
		isThrowRockEnd = true;
	}

	void ThrowStone()
	{
		
		if (!isThrowRockEnd)
		{
			if (!isThrowRock)
			{
				Rigidbody2D stoneInArms = Instantiate(stone, throwPoint.position, Quaternion.identity);
				Vector2 direction = CalculateThrowDirection();
				stoneInArms.AddForce(direction * throwForce, ForceMode2D.Impulse);
				StartCoroutine(ThrowRockDelay());
				isThrowRock = true;
			}
		}
		else
		{
			isThrowRock = false;
			isThrowRockEnd = false;

			status = Status.READY;
		}
	}

	Vector2 CalculateThrowDirection()
	{
		Vector2 playerPosition = player.transform.position;
		Vector2 direction = playerPosition - (Vector2)throwPoint.position;
		direction.Normalize(); 
		return direction;
	}

	// Методы реализующие атаку рогами
	private void HornAttack()
	{
		if (!isInEdge)
		{
			a.Play("CalfRun");
			if (transform.position.x - middleOfArena.position.x < 0)
			{
				GoToEdge(leftEdgeOfArena);
				oppositeEdge = rightEdgeOfArena;
				knockbackDirection = new Vector2(-1, 1).normalized;
			}
			else
			{
				GoToEdge(rightEdgeOfArena);
				oppositeEdge = leftEdgeOfArena;
				knockbackDirection = new Vector2(1, 1).normalized;
			}
		}
		else if(isInEdge && !isInWall)
		{
			a.Play("CalfRunAttack");
			if (Mathf.Abs(oppositeEdge.position.x - transform.position.x) > 0.1f && !isInWall)
			{
				Vector2 direction = (oppositeEdge.position - transform.position).normalized;
				rb.velocity = new Vector2(direction.x * runSpeed, rb.velocity.y);
				if (!isPlayerBoosted)
				{
					player.gameObject.GetComponent<PlayerMovement>().moveSpeed += 1;
					player.gameObject.GetComponent<PlayerMovement>().jumpForce += 1;
					isPlayerBoosted = true;
				}
			}
			else
			{
				rb.velocity = Vector2.zero;
				isInWall = true;
				StartCoroutine(HornAttackActiveDelay());
			}
		}

		if (!stayInWall && isInWall)
		{
			float circleRadius = 1f; // Радиус круглого луча
			if (Physics2D.CircleCast(transform.position, circleRadius, transform.right, 0f, playerLayerMask))
			{
				playerRb.velocity = Vector2.zero;
				player.GetComponent<PlayerMovement>().isFreezing = true;
				playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
				playerHP.Damaging(damage / 2f);
				StartCoroutine(PlayerFreezeDelay());
				StartCoroutine(GiveDamageDelay());
			}

			isInEdge = false;
			isInWall = false;
			stayInWall = false;
			isPlayerBoosted = false;
			player.gameObject.GetComponent<PlayerMovement>().moveSpeed -= 1;
			player.gameObject.GetComponent<PlayerMovement>().jumpForce -= 1;

			status = Status.READY;
		}
	}

	private void GoToEdge(Transform edge)
	{
		if (Mathf.Abs(edge.position.x - transform.position.x) > 0.1f)
		{
			Vector2 direction = (edge.position - transform.position).normalized;
			rb.velocity = new Vector2(direction.x * walkSpeed, rb.velocity.y);
		}
		else
		{
			rb.velocity = Vector2.zero;
			isInEdge = true;
		}
	}

	// Задержка в момент удара о стену
	IEnumerator HornAttackActiveDelay()
	{
		a.Play("CalfDefault");
		stayInWall = true;
		yield return new WaitForSeconds(4f); // Задержка в 1 секунду
		stayInWall = false;
	}

	// Задержка отталкивания игрока после удара
	IEnumerator PlayerFreezeDelay()
	{
		yield return new WaitForSeconds(0.7f); // Задержка в 1 секунду
		playerRb.velocity = Vector2.zero;
		player.GetComponent<PlayerMovement>().isFreezing = false;
	}

	/////

	// поворот босса
	private void Flip()
	{
		if (!isInWall)
		{
			if (rb.velocity.x > 0)
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
			else if (rb.velocity.x <= 0)
				transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		}
	}

	private void GiveDamageWhenPlayerEntersBossCollision()
	{
		if (canAttackWhenBossCollision)
		{
			float boxWidth = 0.2f;
			float boxHeight = 1.28f;
			Vector2 boxCenter;
			if (status == Status.HORNATTACK && isInEdge && !isInWall)
			{
				boxHeight /= 2;
				boxCenter = (Vector2)(transform.position + transform.right * boxWidth / 2f - transform.up * boxHeight / 2f); // Центр прямоугольника
			}
			else
				boxCenter = (Vector2)(transform.position + transform.right * boxWidth / 2f);

			if (Physics2D.OverlapBox(boxCenter, new Vector2(boxWidth, boxHeight), 0f, playerLayerMask))
			{
				playerRb.velocity = Vector2.zero;
				player.GetComponent<PlayerMovement>().isFreezing = true;
				if (rb.velocity.x / Mathf.Abs(rb.velocity.x) <= 0)
					playerRb.AddForce(new Vector2(-1, 1) * knockbackForce, ForceMode2D.Impulse);
				else
					playerRb.AddForce(new Vector2(1, 1) * knockbackForce, ForceMode2D.Impulse);
				playerHP.Damaging(damage);
				StartCoroutine(PlayerFreezeDelay());
				StartCoroutine(GiveDamageDelay());
			}
		}
	}

	IEnumerator GiveDamageDelay()
	{
		canAttackWhenBossCollision = false;
		yield return new WaitForSeconds(2f); // Задержка в 2 секундs
		canAttackWhenBossCollision = true;
	}

	private void OnDrawGizmos()
	{
		float boxWidth = 0.2f; 
		float boxHeight = 1.28f;
		Vector2 boxCenter = Vector2.zero;
		if (status == Status.HORNATTACK && isInEdge && !isInWall)
		{
			boxHeight /= 2;
			boxCenter = (Vector2)(transform.position + transform.right * boxWidth / 2f - transform.up * boxHeight / 2f); // Центр прямоугольника
		}
		else
			boxCenter = (Vector2)(transform.position + transform.right * boxWidth / 2f); 

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(boxCenter, new Vector3(boxWidth, boxHeight, 0f));
	}
}

