using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory
{
    public List<InteractableObjectSO> Items = new List<InteractableObjectSO>(new InteractableObjectSO[30]);

    public void AddItem(InteractableObjectSO item)
    {
        for (int i = 0; i < 30; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = item;
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("�κ��丮�� �� ������ �����ϴ�!");

    }

}
