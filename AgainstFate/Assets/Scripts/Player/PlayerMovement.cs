using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody; // компонент rididbody
    private Vector2 _horizontalVelocity; // вектор(скорость) джижения
    private float _horizontalSpeed; // направление движения

    public float moveSpeed; // множитель скорости 
    public float jumpForce; // множитель прыжка

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // получаем объект Rigidbody игрока
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        Jump();
    }

    // Здесь будет происходить перерасчёт физики
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


