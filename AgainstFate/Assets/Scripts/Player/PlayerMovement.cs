using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D _rigidbody; // компонент rididbody
    private BoxCollider2D _boxCollider;
    private Vector2 _horizontalVelocity; // вектор(скорость) джижения
    private float _horizontalSpeed; // направление движения
    public Animator animator;//переменная для переключения анимаций
    public bool isFreezing = false;

    public float moveSpeed; // множитель скорости 
    public float jumpForce; // множитель прыжка

    public bool isDialog = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // получаем объект Rigidbody игрока
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialog)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetFloat("_horizontalSpeed", 0);
            animator.SetBool("Jumping", false);
        }
        else if (isFreezing)
        {
            animator.SetFloat("_horizontalSpeed", 0);
            animator.SetBool("Jumping", false);
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!isFreezing)
            {
                animator.enabled = true;
                _horizontalSpeed = Input.GetAxis("Horizontal");
                Jump();
                animator.SetFloat("_horizontalSpeed", Mathf.Abs(_horizontalSpeed));
                if (IsGrounded() == false)
                    animator.SetBool("Jumping", true);
                else
                    animator.SetBool("Jumping", false);
            }
        }

    }

    // Здесь будет происходить перерасчёт физики
    private void FixedUpdate()
    {
        if (!isFreezing)
        {
            Move();
            Flip();
        }
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
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        float boxCollideSize = 0.08f;
        // TOFIX Возможно придётся уменьшать ширину для checkGround, чтобы не прыгать от стен, если ничего не придумаем
        RaycastHit2D checkGround = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, boxCollideSize, platformLayerMask);
        Color rayColor = checkGround.collider ? Color.green : Color.red;
        Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + boxCollideSize), rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + boxCollideSize), rayColor);
        Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, _boxCollider.bounds.extents.y + boxCollideSize), Vector2.right * (_boxCollider.bounds.extents.x * 2f), rayColor);
        //Debug.Log(checkGround.collider);
        return checkGround.collider != null;
    }

    
}


