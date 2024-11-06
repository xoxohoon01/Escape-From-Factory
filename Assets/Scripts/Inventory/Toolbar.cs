using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Toolbar
{
    public List<ItemData> Slots = new List<ItemData>(new ItemData[10]);
    public ItemData currentItem { get; private set; }

    // ���� ��� (������ 1������ �� ���� ������ ���)
    public void AddItem(ItemData item)
    {
        // ���ٿ� �̹� �������� �ִٸ� ����
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] != null && Slots[i].Item.Name == item.Item.Name)
            {
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        // ���ٿ� �� �ڸ��� ������ ���
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i] == null)
            {
                Slots[i] = item;
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("���ٿ� �� ������ �����ϴ�!");
    }

    // ������ȣ ��� (������ ������ ��ȣ�� ������ ���)
    public void AddItem(ItemData item, int index)
    {
        if (item != null)
        {
            Slots[index] = item;

            UIManager.Instance.UpdateInventory();
        }
    }
}
