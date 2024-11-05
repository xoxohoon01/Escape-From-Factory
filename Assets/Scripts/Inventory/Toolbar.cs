using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Toolbar
{
    public List<InteractableObjectSO> Items = new List<InteractableObjectSO>(new InteractableObjectSO[10]);

    // ���� ��� (������ 1������ �� ���� ������ ���)
    public void AddItem(InteractableObjectSO item)
    {
        // ���ٿ� �̹� �������� �ִٸ� ����
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] != null && Items[i].Name == item.Name)
            {
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        // ���ٿ� �� �ڸ��� ������ ���
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = item;
                UIManager.Instance.UpdateInventory();
                return;
            }
        }

        Debug.Log("���ٿ� �� ������ �����ϴ�!");
    }

    // ������ȣ ��� (������ ������ ��ȣ�� ������ ���)
    public void AddItem(InteractableObjectSO item, int index)
    {
        if (item != null)
        {
            Items[index] = item;

            UIManager.Instance.UpdateInventory();
        }
    }
}
