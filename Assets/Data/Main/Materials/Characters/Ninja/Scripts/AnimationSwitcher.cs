using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerMove _physicsMovement;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        SwitchAnimation();
    }


    private void SwitchAnimation()
    {
        if (_rigidbody.velocity.x > 0f)
        {
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isRacing", true);
            _spriteRenderer.flipX = false;
        }
        else if (_rigidbody.velocity.x < 0f)
        {
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isRacing", true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _animator.SetBool("isRacing", false);
            _animator.SetBool("isIdle", true);
        }

        if (_rigidbody.velocity.x > 2f)
        {
            _animator.SetBool("isRunning", true);
        }
        else if (_rigidbody.velocity.x < 2f)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isIdle", true);
        }

        if (_rigidbody.velocity.x == 0f)
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isRacing", false);
            _animator.SetBool("isIdle", true);
        }
    }
}
