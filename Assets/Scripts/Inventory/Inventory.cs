using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory
{
    public List<ItemData> Slots = new List<ItemData>(new ItemData[30]);

    public void AddItem(InteractableObjectSO item)
    {
        for (int i = 0; i < 30; i++)
        {
            if (Slots[i] != null && Slots[i].Item.Name == item.name)
            {
                if (Slots[i].Stack < 99)
                {
                    Slots[i].Stack += 1;
                    return;
                }
            }
            
        }
        for (int i = 0; i < 30; i++)
        {
            if (Slots[i] == null)
            {
                Slots[i] = new ItemData(item);
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("인벤토리에 빈 공간이 없습니다!");

    }

}
