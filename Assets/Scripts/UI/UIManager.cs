using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Object")]
    // �κ��丮 UI (ĵ���� ���� ������Ʈ)
    public GameObject Inventory;

    [Header("Prefab")]
    // �κ��丮 ���� ������
    public GameObject InventorySlotPrefab;

    private static UIManager instance;
    public static UIManager Instance
    {
        get 
        {
            if (instance != null)
                return instance;
            else
            {
                GameObject newUIManager = Instantiate(new GameObject());
                newUIManager.AddComponent<UIManager>();
                return instance = newUIManager.GetComponent<UIManager>();
            }
        }
    }

    public void UpdateInventory(List<ItemData> inventory)
    {
        for (int i = 0; i < Inventory.transform.childCount; i++)
        {
            if (inventory[i].ID != 0)
                Inventory.transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = inventory[i].ID.ToString();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(InventorySlotPrefab, Inventory.transform);
        }
    }
}
