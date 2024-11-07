using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryController : MonoBehaviour
{
    private Player player;

    public bool isInventoryOpen = false;
    public Inventory inventory = new Inventory();
    public Toolbar toolbar = new Toolbar();

    // Tab ������ UIManager�� InventoryCanvas�� Inventory ���� ����
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
        if (Input.GetKey(KeyCode.Alpha1))
        {
            toolbar.Select(0);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            toolbar.Select(1);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            toolbar.Select(2);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            toolbar.Select(3);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            toolbar.Select(4);
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            toolbar.Select(5);
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            toolbar.Select(6);
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            toolbar.Select(7);
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            toolbar.Select(8);
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            toolbar.Select(9);
        }

        if (toolbar.currentItem != null && toolbar.currentItem.Item.Type == ItemType.Weapon)
        {
            if (player.equipment.currentEquipTool == null)
            {
                player.equipment.EquipNew(toolbar.currentItem.Item);
            }
            else if(player.equipment.currentEquipTool.TryGetComponent(out InteractableObject component))
            {
                if (component.objectSO != toolbar.currentItem.Item)
                {
                    player.equipment.EquipNew(toolbar.currentItem.Item);
                }
            }
        }
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (toolbar.currentItem != null && toolbar.currentItem.Item != null)
            {
                // ������ ������ ���� �ν�
                switch (toolbar.currentItem.Item.Type)
                {
                    // �Ҹ�ǰ�� ���
                    case ItemType.Consumable:

                        // SO�� ����� ID���� ���� ��� ����
                        if (toolbar.currentItem.Item.ID == 0)
                        {
                            Debug.Log("ü�� ����");
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
                        // �Ҹ��ϱ�
                        break;

                    // ������ ���
                    case ItemType.Weapon:
                        player.equipment.OnAttack();
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
