using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    EnemyController controller;
    EnemyCondition condition;
    EnemyAnimationController animationController;

    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        condition = GetComponent<EnemyCondition>();
        animationController = GetComponent<EnemyAnimationController>();

    }

    private void Update()
    {
        // Action 형식으로 연결해서 controller에서 값이 바뀌면 같이 바뀌도록 설정할 것
        // 또는 animationController
        if (controller.isMove)
        {
            animationController.animator.SetFloat("speed", GetComponent<Rigidbody>().velocity.magnitude);
            animationController.animator.speed = 1;
        }
        else
        {
            animationController.animator.SetFloat("speed", 0);
            animationController.animator.speed = 1;
        }
    }
}
