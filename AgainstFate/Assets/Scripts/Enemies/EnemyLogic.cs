using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    // определ€ет поведение врага
    public enum Status
    {
        patrol = 0, // статус патрулировани€
        pursuit = 1 // статут преследовани€
    }

    private Rigidbody2D rb; // rigidbody2d противника 

    public Transform[] waypoints; // массив точек следовани€ противника
    private int currentWaypointIndex = 0; // индекс точки, к которой прив€зан противник

    public Transform player; // положение игрока
    public Status status = Status.patrol; // статус противника

    public float speed = 1f; // скорость противника
    public float jumpForce = 5f;

    public float visionRange = 5f; // дальность видимости противника
    public float visionAngle = 45f; // угол обзора противника
    public LayerMask targetLayer; // слой объектов, которые противник может видеть

    private BoxCollider2D _boxCollider;
    private bool canJump = true;
    private bool canAttack = true;
    [SerializeField] private LayerMask platformLayerMask;
    public Transform[] jumpPoints;
    public Transform actualJumpPoint;
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public float damage = 25;
    private bool isBeforeAttack = false;
    public bool isStuck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        MoveToWaypoint();
    }

    // метод следовани€ к точке маршрута
    void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        Vector2 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    void Update()
    {
        if (status == Status.pursuit)
        {
            Pursuit();
        }
        else if (status == Status.patrol)
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                if (waypoints[currentWaypointIndex % waypoints.Length].GetComponent<PatrolWayPointController>().IsJump(rb.velocity.x))
                    Jump();
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                MoveToWaypoint();
            }
        }

        Flip();

        // блок кода провер€ет есть ли игрок в зоне видимости или нет. ≈сли есть, то мен€ет статут на pursuit
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, visionRange, targetLayer);
        if (hit.collider != null)
        {
            Vector2 directionToTarget = hit.point - (Vector2)transform.position;
            float angle = Vector2.Angle(transform.right, directionToTarget);

            if (angle <= visionAngle / 2)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                status = Status.pursuit;
                Debug.Log("Player detected!");
            }
        }
    }

    // поворот противника
    private void Flip()
    {
        if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    public void Pursuit()
    {
        Collider2D[] goodObjs = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        FindCloserPoint();
        if (!canAttack && IsGrounded())
        {
            Vector3 direction = player.position - transform.position;
            rb.velocity = new Vector2(direction.x * speed / 2, rb.velocity.y);
        }
        else
        {
            BeforeAttack(goodObjs);
            if ((player.GetComponent<BoxCollider2D>().bounds.min.y < _boxCollider.bounds.max.y || !IsGrounded()) && !isStuck)
            {
                Vector3 direction = player.position - transform.position;
                direction.Normalize();
                rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            }
            else if (player.GetComponent<BoxCollider2D>().bounds.min.y >= _boxCollider.bounds.max.y || isStuck)
            {
                Debug.Log("IsStuck" + isStuck);
                Vector3 direction = actualJumpPoint.position - transform.position;
                direction.Normalize();
                rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
                if ((canJump && IsGrounded() && Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < 0.1f) || (canJump && isStuck && IsGrounded() && Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < 0.1f))
                {
                    StartCoroutine(JumpDelay());
                    Jump();
                    isStuck = false;
                }
            }
        }
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = transform.right;
        if (Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, wallLayer) && 
            player.GetComponent<BoxCollider2D>().bounds.min.y < _boxCollider.bounds.max.y &&
            Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < Mathf.Abs(player.position.x - transform.position.x))
        {
            Debug.Log("”дар о стену!");
            isStuck = true;
        }
    }

    // Ќаходим ближайшую точку прыжка к игроку
    public void FindCloserPoint()
    {
        Transform closestJumpPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform jumpPoint in jumpPoints)
        {
            float distance = Vector3.Distance(jumpPoint.position, transform.position);
            if (distance < closestDistance && !(jumpPoint.position.y > gameObject.GetComponent<BoxCollider2D>().bounds.min.y + 0.3))
            {
                closestJumpPoint = jumpPoint;
                closestDistance = distance;
            }
        }

        if (closestJumpPoint != null)
        {
            actualJumpPoint = closestJumpPoint;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        float boxCollideSize = 0.08f;
        RaycastHit2D checkGround = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, boxCollideSize, platformLayerMask);
        Color rayColor = checkGround.collider ? Color.green : Color.red;
        return checkGround.collider != null;
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f); // «адержка в 1 секунду
        canAttack = true;
        isBeforeAttack = false;
    }

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(0.7f); // «адержка в 1 секунду
        canJump = true;
    }

    IEnumerator BeforeAttackDelay()
    {
        yield return new WaitForSeconds(0.5f); // «адержка в 1 секунду
        isBeforeAttack = true;
    }

    private void BeforeAttack(Collider2D[] goodObjs)
    {
        Debug.Log(isBeforeAttack);
        if (canAttack)
        {
            if (!isBeforeAttack && goodObjs.Length != 0)
            {
                StartCoroutine(BeforeAttackDelay());
            }
            else if (isBeforeAttack)
            {
                Attack(goodObjs);
            }
        }
    }
    private void Attack(Collider2D[] goodObjs)
    {
        if (canAttack)
        {
            foreach (Collider2D goodObj in goodObjs)
            {
                if (goodObj.gameObject.layer == 3)
                {
                    player.gameObject.GetComponent<HP>().Damaging(damage);
                }
            }
            StartCoroutine(AttackDelay());
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, visionAngle / 2) * transform.right * visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -visionAngle / 2) * transform.right * visionRange);

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position + boxCenter, boxSize);
    }

    public float rayDistance = 0.16f;
    public LayerMask wallLayer;


}
