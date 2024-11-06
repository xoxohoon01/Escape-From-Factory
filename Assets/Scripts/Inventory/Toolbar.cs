using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Toolbar
{
    public List<ItemData> Slots = new List<ItemData>(new ItemData[10]);
    public ItemData currentItem { get; private set; }

    // 빠른 등록 (툴바의 1번부터 빈 곳에 아이템 등록)
    public void AddItem(ItemData item)
    {
        // 툴바에 이미 아이템이 있다면 리턴
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] != null && Slots[i].Item.Name == item.Item.Name)
            {
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        // 툴바에 빈 자리에 아이템 등록
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] == null)
            {
                Slots[i] = item;
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("툴바에 빈 공간이 없습니다!");
    }

    // 지정번호 등록 (툴바의 지정한 번호로 아이템 등록)
    public void AddItem(ItemData item, int index)
    {
        if (item != null)
        {
            Slots[index] = item;

            UIManager.Instance.UpdateInventory();
        }
    }
}
