using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraAttackLogic : MonoBehaviour
{
    private Animator animator;
    public string AttackAnim, Defaultanim;
    // ���������� ��������� �����
    public enum Status
    {
        patrol = 0, // ������ ��������������
        pursuit = 1, // ������ �������������
        heal = 2
    }

    private Rigidbody2D rb; // rigidbody2d ���������� 

    public Transform[] waypoints; // ������ ����� ���������� ����������
    private int currentWaypointIndex = 0; // ������ �����, � ������� �������� ���������

    public Transform player; // ��������� ������
    public Status status = Status.patrol; // ������ ����������

    public float speed = 1f; // �������� ����������
    public float jumpForce = 5f;

    public float visionRange = 5f; // ��������� ��������� ����������
    public float visionAngle = 45f; // ���� ������ ����������
    public LayerMask targetLayer; // ���� ��������, ������� ��������� ����� ������

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
    public GameObject hpimage;

    private bool heal = true;

    public LibraHP hp;
    private HP playerhp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        playerhp = player.GetComponent<HP>();
        MoveToWaypoint();
    }

    // ����� ���������� � ����� ��������
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
        
        if (hp.hp<playerhp.nowHP && hp.hp < 30 && heal)
        {
            
            status = Status.heal;
        }
        else
            status = Status.pursuit;
        if (status == Status.pursuit)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true;
            Pursuit();
            
            MoveToWaypoint();
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
        else if (status == Status.heal)
        {
            StopAllCoroutines();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            animator.Play(Defaultanim);//�������� ���������� ��
            hp.Heal(playerhp.nowHP);
            StartCoroutine(HealWait());
            
            
        }

        Flip();

        // ���� ���� ��������� ���� �� ����� � ���� ��������� ��� ���. ���� ����, �� ������ ������ �� pursuit
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

    // ������� ����������
    private void Flip()
    {
        if (rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        hpimage.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    public void Pursuit()
    {
        Collider2D[] goodObjs = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        FindCloserPoint();
        if (!canAttack && IsGrounded())
        {
            //Vector3 direction = player.position - transform.position;
            //rb.velocity = new Vector2(direction.x * speed / 2, rb.velocity.y);
            rb.velocity = Vector2.zero;
        }
        else
        {
            BeforeAttack(goodObjs);
            if ((player.GetComponent<BoxCollider2D>().bounds.min.y < _boxCollider.bounds.max.y) && !isStuck) // || !IsGrounded()  && !isMozhno
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

                //if ((!CanReachPlayerFromPoint(actualJumpPoint.position)) && !isStuck) // || isMozhno
                //{
                //	if (!isMozhno)
                //		FindCloserPointForJumpPoint();
                //	if (Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < 0.1f || isMozhno && !isStuck)
                //	{
                //		isMozhno = true;
                //		direction = nextJumpPoint.position - transform.position;
                //		direction.Normalize();
                //		rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
                //		if (Mathf.Abs(transform.position.x - nextJumpPoint.position.x) < 0.1f)
                //		{
                //			if (!CanReachPlayerFromPoint(actualJumpPoint.position))
                //				FindCloserPointForJumpPoint();
                //			else
                //				isMozhno = false;
                //		}
                //	}
                //	if (Mathf.Abs(actualJumpPoint.position.x - transform.position.x) > 0.1f && isMozhno && IsGrounded())
                //	{
                //		direction = actualJumpPoint.position - transform.position;
                //		direction.Normalize();
                //		rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
                //	}
                //}
                if ((canJump && IsGrounded() && Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < 0.1f) || (canJump && isStuck && IsGrounded() && Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < 0.1f))
                {
                    StartCoroutine(JumpDelay());
                    Jump();
                    isStuck = false;
                    //isMozhno = false;
                }

            }
        }
        // Vector2 rayOrigin = transform.position;
        if (!isStackBefore)
        {
            Vector2 rayDirection = transform.right;
            Vector2 headRayOrigin = (Vector2)transform.position + Vector2.up * _boxCollider.bounds.size.y / 2; // ������� ������ �����
            Vector2 feetRayOrigin = (Vector2)transform.position - Vector2.up * _boxCollider.bounds.size.y / 2; // ������� ��� �����

            if ((Physics2D.Raycast(headRayOrigin, rayDirection, rayDistance, wallLayer) || Physics2D.Raycast(feetRayOrigin, rayDirection, rayDistance, wallLayer)) /*&&
                player.GetComponent<BoxCollider2D>().bounds.min.y < _boxCollider.bounds.max.y*/ &&
                Mathf.Abs(actualJumpPoint.position.x - transform.position.x) < Mathf.Abs(player.position.x - transform.position.x))
            {
                Debug.Log("���� � �����!");
                isStuck = true;
                StartCoroutine(StackDelay());
            }
        }
    }

    public Transform nextJumpPoint;
    bool isMozhno = false;
    public void FindCloserPointForJumpPoint()
    {
        Transform closestJumpPoint = null;
        float closestDistance = Mathf.Infinity;
        nextJumpPoint = actualJumpPoint;
        foreach (Transform jumpPoint in jumpPoints)
        {
            float distance = Vector3.Distance(jumpPoint.position, nextJumpPoint.position);
            if (distance < closestDistance && (jumpPoint.position.y > nextJumpPoint.position.y))
            {
                closestJumpPoint = jumpPoint;
                closestDistance = distance;
            }
        }

        if (closestJumpPoint != null)
        {
            nextJumpPoint = closestJumpPoint;
        }
    }
    private bool CanReachPlayerFromPoint(Vector3 point)
    {
        RaycastHit2D hit = Physics2D.Linecast(point, player.position, platformLayerMask);
        return hit.collider == null || hit.collider.gameObject == player.gameObject;
    }

    private bool isStackBefore = false;
    IEnumerator StackDelay()
    {
        isStackBefore = true;
        yield return new WaitForSeconds(0.3f); // 
        isStackBefore = false;
    }

    // ������� ��������� ����� ������ � ������
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
        yield return new WaitForSeconds(1f); // �������� � 1 �������
        canAttack = true;
        isBeforeAttack = false;
    }

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(0.7f); // �������� � 1 �������
        canJump = true;
    }
    IEnumerator HealWait()
    {
        heal = false;
        yield return new WaitForSeconds(15f);
        heal = true;
    }

    IEnumerator BeforeAttackDelay()
    {
        animator.Play(AttackAnim);
        yield return new WaitForSeconds(0.5f); // �������� � 1 �������
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
                //animator.Play("MaideReadyToAttack");
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

        Vector2 headRayOrigin = (Vector2)transform.position + Vector2.up * _boxCollider.bounds.size.y / 2; // ������� ������ �����
        Vector2 feetRayOrigin = (Vector2)transform.position - Vector2.up * _boxCollider.bounds.size.y / 2; // ������� ��� �����
        Vector2 rayDirection = transform.right;

        Gizmos.color = Color.red;
        Debug.DrawRay(headRayOrigin, rayDirection * rayDistance);
        Gizmos.DrawWireSphere(headRayOrigin + rayDirection * rayDistance, 0.1f); // ����������� �������� ����� ����

        Gizmos.color = Color.blue;
        Debug.DrawRay(feetRayOrigin, rayDirection * rayDistance);
        Gizmos.DrawWireSphere(feetRayOrigin + rayDirection * rayDistance, 0.1f); // ����������� �������� ����� ����
    }

    public float rayDistance = 0.02f;
    public LayerMask wallLayer;
}