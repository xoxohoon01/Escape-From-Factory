using UnityEngine;

public class Storage : MonoBehaviour, IInteractable
{
    // 인벤토리 필드 추가
    //public Inventory inventory; 

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