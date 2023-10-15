using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody; // ��������� rididbody
    private Vector2 _horizontalVelocity; // ������(��������) ��������
    private float _horizontalSpeed; // ����������� ��������

    public float moveSpeed; // ��������� �������� 
    public float jumpForce; // ��������� ������

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // �������� ������ Rigidbody ������
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        Jump();
    }

    // ����� ����� ����������� ���������� ������
    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        _horizontalVelocity.Set(_horizontalSpeed * moveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = _horizontalVelocity;
    }

    private void Flip()
    {
        if (_horizontalSpeed > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (_horizontalSpeed < 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}


