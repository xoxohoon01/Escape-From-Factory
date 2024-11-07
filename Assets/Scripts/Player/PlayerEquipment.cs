using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public EquipTool currentEquipTool;
    public Transform equipParent;
    private PlayerAttackController attackController;

    public void EquipNew(InteractableObjectSO data)
    {
        UnEquip();
        Debug.Log("Equip");
        currentEquipTool = Instantiate(data.equipPrefab, equipParent).GetComponent<EquipTool>();
        attackController.AttackRange.weapon = currentEquipTool;
    }

    public void UnEquip()
    {
        if (currentEquipTool != null)
        {
            Destroy(currentEquipTool.gameObject);
            currentEquipTool = null;
        }
    }

    public void OnAttack()
    {
        currentEquipTool.OnAttackInput();
        attackController.Attack();
    }

    private void Awake()
    {
        attackController = GetComponent<PlayerAttackController>();
    }
}
