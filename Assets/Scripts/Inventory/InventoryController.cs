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

    public InteractableObjectSO currentItem{ get; private set; }

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
        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentItem = toolbar.Slots[0].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            currentItem = toolbar.Slots[1].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            currentItem = toolbar.Slots[2].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            currentItem = toolbar.Slots[3].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            currentItem = toolbar.Slots[4].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            currentItem = toolbar.Slots[5].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            currentItem = toolbar.Slots[6].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            currentItem = toolbar.Slots[7].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            currentItem = toolbar.Slots[8].Item;
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            currentItem = toolbar.Slots[9].Item;
        }
    }

    private void Use()
    {
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
    }
}
