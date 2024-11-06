using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ���� ���õ� �κ��丮�� ����, �ٲ� ��� UI�� ������ �ٲ�
    private Inventory currentInventory;
    private Toolbar currentToolbar;

    [Header("Object")]
    // �κ��丮 UI (ĵ���� ���� ������Ʈ)
    public SlotMenu InventoryUI;
    public SlotMenu ToolbarUI;

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


    // �κ��丮 UI ���� (�÷��̾� �κ��丮����, ���� �κ��丮���� ���� ������ ���� �ٸ� �κ��丮 ��������)
    public void OpenInventory(Inventory inventory)
    {
        InventoryUI.gameObject.SetActive(true);
        currentInventory = inventory;
        UpdateInventory();
    }

    // ���� ������ ������Ʈ
    public void OpenToolbar(Toolbar toolbar)
    {
        ToolbarUI.gameObject.SetActive(true);
        currentToolbar = toolbar;
        UpdateInventory();
    }

    // �κ��丮 UI ������Ʈ (�̹��� �ֽ�ȭ)
    public void UpdateInventory()
    {
        // ���� ���õ� �κ��丮�� ���� ���� ������Ʈ
        if (currentInventory != null)
        {
            // �κ��丮 ������ �̹��� ����
            for (int i = 0; i < InventoryUI.Slots.Count; i++)
            {
                if (currentInventory.Slots[i] != null)
                {
                    InventoryUI.Slots[i].image.sprite = currentInventory.Slots[i].Item.icon;
                    InventoryUI.Slots[i].stackText.text = currentInventory.Slots[i].Stack.ToString();
                }
            }
        }

        if (currentToolbar != null)
        {
            // ���� �̹��� ����
            for (int i = 0; i < ToolbarUI.Slots.Count; i++)
            {
                if (currentToolbar.Slots[i] != null)
                {
                    ToolbarUI.Slots[i].image.sprite = currentToolbar.Slots[i].Item.icon;
                    ToolbarUI.Slots[i].stackText.text = currentToolbar.Slots[i].Stack.ToString();
                }
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

}
