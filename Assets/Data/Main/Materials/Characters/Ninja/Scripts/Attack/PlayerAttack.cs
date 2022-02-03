using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [Header("Set target and damage")]
    [SerializeField] private BanditEnemy _banditEnemy;
    [SerializeField] private int _damage = 10;
    
    private InputSystem _inputSystem; //setup input system

    private Rigidbody2D _rigidbody;
    private GameObject _banditBoss;
    
    
    private float _attackDelay;
    private RaycastHit2D[] _raycasts;
    private ContactFilter2D _contacts;
    private bool _canTouched;
    private float _maxDistanceToAttack = 3;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Player.Attack.performed += ctx => OnAttack();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void FixedUpdate()
    {
        checkDistance();
    }

    private void checkDistance()
    {
        if(_banditEnemy != null)
        {
            Vector2 distanceBetweenEnemy = _banditEnemy.transform.position - transform.localPosition;

            float distance = distanceBetweenEnemy.magnitude;

            if (distance <= _maxDistanceToAttack)
            {
                _canTouched = true;
            }
            else
            {
                _canTouched = false;
            }
        }
    }

    public void OnAttack()
    {
        if(_banditEnemy != null)
        {
            if (_canTouched)
            {
                _banditEnemy.ApplyDamage(_damage);
                Debug.Log("bandit was attacked");
            }
        }
        
    }

}
