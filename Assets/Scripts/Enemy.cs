using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    EnemyCondition condition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
