using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 현재 선택된 인벤토리와 툴바, 바뀔 경우 UI의 내용이 바뀜
    private Inventory currentInventory;
    private Toolbar currentToolbar;

    [Header("Object")]
    // 인벤토리 UI (캔버스 하위 오브젝트)
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


    // 인벤토리 UI 변경 (플레이어 인벤토리인지, 상자 인벤토리인지 등의 정보에 따라 다른 인벤토리 열리도록)
    public void OpenInventory(Inventory inventory)
    {
        InventoryUI.gameObject.SetActive(true);
        currentInventory = inventory;
        UpdateInventory();
    }

    // 툴바 데이터 업데이트
    public void OpenToolbar(Toolbar toolbar)
    {
        ToolbarUI.gameObject.SetActive(true);
        currentToolbar = toolbar;
        UpdateInventory();
    }

    // 인벤토리 UI 업데이트 (이미지 최신화)
    public void UpdateInventory()
    {
        // 현재 선택된 인벤토리가 있을 때만 업데이트
        if (currentInventory != null)
        {
            // 인벤토리 아이템 이미지 변경
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
            // 툴바 이미지 변경
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
