using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    private int maxInventory = 30;
    [SerializeField] private List<ItemData> Items = new List<ItemData>();

    public void InitInventory()
    {
        Items.Clear();
        for (int i = 0; i < maxInventory; i++)
        {
            Items.Add(new ItemData());
        }
    }

    public void AddItem(ItemData newItem)
    {
        // ������ �߰� ���� ����
        bool isAdded = false;

        for (int i = 0; i < Items.Count; i++)
        {
            // �κ��丮�� ��ĭ�� �ִ��� Ȯ��
            if (Items[i].ID == 0)
            {
                Items[i] = newItem;
                isAdded = true;
                break;
            }
        }
        if (!isAdded) Debug.Log("�κ��丮�� �� á���ϴ�!");
        UIManager.Instance.UpdateInventory(Items);
    }

    //�κ��丮�� �������� �ִ��� Ȯ��
    public ItemData Exsist(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == id)
            {
                return Items[i];
            }
        }
        return null;
    }

    private void Awake()
    {
        InitInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddItem(new ItemData(1));
        }
    }
}
