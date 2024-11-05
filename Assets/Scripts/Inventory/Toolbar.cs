using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Toolbar
{
    public List<InteractableObjectSO> Items = new List<InteractableObjectSO>(new InteractableObjectSO[10]);

    // 빠른 등록 (툴바의 1번부터 빈 곳에 아이템 등록)
    public void AddItem(InteractableObjectSO item)
    {
        // 툴바에 이미 아이템이 있다면 리턴
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] != null && Items[i].Name == item.Name)
            {
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        // 툴바에 빈 자리에 아이템 등록
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = item;
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("툴바에 빈 공간이 없습니다!");
    }

    // 지정번호 등록 (툴바의 지정한 번호로 아이템 등록)
    public void AddItem(InteractableObjectSO item, int index)
    {
        if (item != null)
        {
            Items[index] = item;

            UIManager.Instance.UpdateInventory();
        }
    }
}
