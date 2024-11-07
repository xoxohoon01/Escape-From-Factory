using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public AttackRangeScript AttackRange;

    float attackDelay = 1;
    float attackSpan = 1;

    float nowAttackDelay = 0;
    float nowAttackSpan = 0;

    public void Attack()
    {
        if (nowAttackDelay <= 0)
        {
            nowAttackDelay = attackDelay;
            nowAttackSpan = attackSpan;
            AttackRange.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (nowAttackDelay > 0) nowAttackDelay -= Time.deltaTime;
        if (nowAttackSpan > 0)
        {
            nowAttackSpan -= Time.deltaTime;
            if (nowAttackSpan <= 0)
            {
                AttackRange.gameObject.SetActive(false);
            }
        }
    }
}
