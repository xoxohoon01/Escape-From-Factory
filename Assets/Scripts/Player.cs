using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private PlayerController controller;
    private PlayerCondition condition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
