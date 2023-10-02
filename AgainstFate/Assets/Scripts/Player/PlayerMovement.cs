using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _horizontalVelocity;
    private float _horizontalSpeed;

    public float MoveSpeed; // �������� ������������ ������

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // �������� ������ Rigidbody ������
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
    }

    // ����� ����� ����������� ���������� ������
	private void FixedUpdate()
	{
        Move();
    }

    private void Move()
    {
        _horizontalVelocity.Set(_horizontalSpeed * MoveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = _horizontalVelocity;
    }
}
