using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // определяет поведение врага
    public enum Status
    {
        patrol = 0, // статус патрулирования
        pursuit = 1 // статут преследования
    }

    private Rigidbody2D rb; // rigidbody2d противника 

    public Transform[] waypoints; // массив точек следования противника
    private int currentWaypointIndex = 0; // индекс точки, к которой привязан противник

    public Transform player; // положение игрока
    public Status status = Status.patrol; // статус противника

    public float speed = 1f; // скорость противника
    public float jumpForce = 5f;

    public float visionRange = 5f; // дальность видимости противника
    public float visionAngle = 45f; // угол обзора противника
    public LayerMask targetLayer; // слой объектов, которые противник может видеть

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveToWaypoint();
    }

    // метод следования к точке маршрута
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
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
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

        // блок кода проверяет есть ли игрок в зоне видимости или нет. Если есть, то меняет статут на pursuit
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

    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, visionAngle / 2) * transform.right * visionRange);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -visionAngle / 2) * transform.right * visionRange);
    }
}
