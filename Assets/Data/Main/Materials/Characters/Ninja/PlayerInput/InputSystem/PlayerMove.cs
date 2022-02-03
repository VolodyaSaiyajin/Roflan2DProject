using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;

    public Vector2 _moveDir;
    public Vector2 _jumpDir;


    [SerializeField] private Rigidbody2D _rb2d;
    private RaycastHit2D[] _hitGround = new RaycastHit2D[1];
    private Vector2 _lineToGround;
    private bool _isGround;
    [SerializeField] private ContactFilter2D _contactFilter;

    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _lineToGround = new Vector2(transform.position.x, transform.position.y - 2);

    }

    private void FixedUpdate()
    {
        Move();
        GroundCheck();
        if (_jumpDir.y != 0)
        {
            if (_isGround == true)
            {
                Jump(_jumpDir);
            }
        }

    }

    public void SetMoveDirection(Vector2 moveDir)
    {
        _moveDir = moveDir;
    }

    public void SetJumpDir(float jumpDir)
    {
        _jumpDir.y = jumpDir;
    }

    private void GroundCheck()
    {
        _isGround = true;
        int collisionsCount = _rb2d.Cast(_lineToGround, _contactFilter, _hitGround, 1);

        if (collisionsCount >= 1)
        {
            Gizmos.color = Color.green;
            _isGround = false;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Debug.Log(_isGround);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _lineToGround);
        
    }

    private void Move()
    {
        _rb2d.velocity = new Vector2(_moveDir.x * _moveSpeed, _rb2d.velocity.y);
    }

    private void Jump(Vector2 jumpDir)
    {
        _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpDir.y * _jumpSpeed);
    }
}
