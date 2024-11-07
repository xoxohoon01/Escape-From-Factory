using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCondition : Unit, IDamagable
{
    public EnemyConditionSO SO;
    private Animator animator;
    private float Health;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Health = SO.HP;
    }

    private void Subtract(float amount)
    {
        Health = Mathf.Max(Health - amount, 0);
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("death");
        Destroy(gameObject, 3f);
    }

    public void TakePhysicalDamage(float damage)
    {
        Subtract(damage);
    }

}
