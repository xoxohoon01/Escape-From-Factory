using UnityEngine;

public class Storage : InteractableObject, IInteractable
{
    public Inventory StorageInventory;
    public bool IsObtainable()
    {
        return false;
    }
    public void Interact()
    {
        OpenInventory();
    }

    void OpenInventory()
    {
        // 인벤토리 열기
        // UI 표시와 데이터 로딩
    }
}