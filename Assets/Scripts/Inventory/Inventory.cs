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
        // 아이템 추가 성공 여부
        bool isAdded = false;

        for (int i = 0; i < Items.Count; i++)
        {
            // 인벤토리에 빈칸이 있는지 확인
            if (Items[i].ID == 0)
            {
                Items[i] = newItem;
                isAdded = true;
                break;
            }
        }
        if (!isAdded) Debug.Log("인벤토리가 꽉 찼습니다!");
        UIManager.Instance.UpdateInventory(Items);
    }

    //인벤토리에 아이템이 있는지 확인
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
