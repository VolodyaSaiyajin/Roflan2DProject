using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Vector2 Velocity;

    [SerializeField] private int _moveSpeed;
    private float _horizontalMove;



    protected Vector2 targetVelocity;
    protected Rigidbody2D rb2d;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(dirX * _moveSpeed * Time.deltaTime, rb2d.velocity.y);
        Velocity.x = _horizontalMove;
    }

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        
    }
}
