using UnityEngine;

public class Storage : Object, IInteractable
{
    public Inventory StorageInventory; 

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