using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    EnemyCondition condition;
    EnemyAnimationController animationController;

    private void Awake()
    {
        condition = GetComponent<EnemyCondition>();
        animationController = GetComponent<EnemyAnimationController>();

    }
}
