using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCondition : MonoBehaviour
{
    public EnemyConditionSO SO;

    private Condition HP;

    private void Awake()
    {
        HP = new Condition(SO.HP);
    }
}