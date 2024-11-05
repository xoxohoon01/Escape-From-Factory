using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryController : MonoBehaviour
{
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
            currentItem = toolbar.Items[0];
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            currentItem = toolbar.Items[1];
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            currentItem = toolbar.Items[2];
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            currentItem = toolbar.Items[3];
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            currentItem = toolbar.Items[4];
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            currentItem = toolbar.Items[5];
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            currentItem = toolbar.Items[6];
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            currentItem = toolbar.Items[7];
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            currentItem = toolbar.Items[8];
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            currentItem = toolbar.Items[9];
        }
    }

    private void Awake()
    {
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
