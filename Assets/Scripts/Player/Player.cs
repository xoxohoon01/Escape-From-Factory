using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerInteraction interaction;
    public InventoryController inventory;
    public PlayerEquipment equipment;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        interaction = GetComponent<PlayerInteraction>();
        inventory = GetComponent<InventoryController>();
        equipment = GetComponent<PlayerEquipment>();
    }
}
