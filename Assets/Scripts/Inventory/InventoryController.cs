using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryController : MonoBehaviour
{
    private Player player;

    public bool isInventoryOpen = false;
    public Inventory inventory = new Inventory();
    public Toolbar toolbar = new Toolbar();

    // Tab 누르면 UIManager의 InventoryCanvas로 Inventory 정보 전달
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnToggle();
        }
    }

    private void OnToggle()
    {
        if (!isInventoryOpen)
        {
            isInventoryOpen = true;
            Cursor.lockState = CursorLockMode.None;
            UIManager.Instance.OpenInventory(inventory);
        }
        else
        {
            isInventoryOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            UIManager.Instance.InventoryUI.gameObject.SetActive(false);
        }
    }

    private void SelectTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toolbar.Select(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            toolbar.Select(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            toolbar.Select(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            toolbar.Select(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            toolbar.Select(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            toolbar.Select(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            toolbar.Select(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            toolbar.Select(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            toolbar.Select(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            toolbar.Select(9);
        }
    }

    public void SelectTool(int inventoryIndex)
    {
        toolbar.AddItem(inventory.Slots[inventoryIndex]);
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (toolbar.currentItem != null && toolbar.currentItem.Item != null)
            {
                // 선택한 아이템 종류 인식
                switch (toolbar.currentItem.Item.Type)
                {
                    // 소모품일 경우
                    case ItemType.Consumable:

                        // SO에 저장된 ID값에 따라 기능 구현
                        if (toolbar.currentItem.Item.ID == 0)
                        {
                            Debug.Log("체력 오름");
                            player.condition.HP.Add(50);
                        }
                        else if (toolbar.currentItem.Item.ID == 1)
                        {
                            player.condition.Stamina.Add(50);
                        }
                        else if (toolbar.currentItem.Item.ID == 2)
                        {
                            player.condition.Hunger.Add(50);
                        }

                        // 사용 시 아이템 소모
                        if (toolbar.currentItem.Stack > 1)
                        {
                            toolbar.currentItem.Stack--;
                        }

                        // 인벤토리 업데이트
                        UIManager.Instance.UpdateInventory();

                        break;
                        
                    // 무기일 경우
                    case ItemType.Weapon:
                        // 때리기 Equipment
                        break;
                }
            }
        }
    }

    private void Awake()
    {
        player = GetComponent<Player>();

        inventory = new Inventory();
        toolbar = new Toolbar();
    }

    private void Start()
    {
        UIManager.Instance.OpenToolbar(toolbar);
    }

    private void Update()
    {
        SelectTool();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            toolbar.AddItem(inventory.Slots[0]);
        }
    }
}
