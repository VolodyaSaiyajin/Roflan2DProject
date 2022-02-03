using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditEnemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private int _maxHealth;
    private int _damage;



    private void Attack()
    {
        
    }
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("Enemy is dead");
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
            
        }
        Debug.Log($"Enemy health: {_health}" );
    }
}
