using UnityEngine;

public class ElectricSource : InteractableObject, IInteractable
{
    public bool isOn;
    public int MaxPower;
    public int CurPower;
    public float PowerRange;

    public LayerMask powerableLayer;
    public bool IsObtainable()
    {
        return false;
    }
    public void Interact()
    {
        if (!isOn)
        {
            isOn = true;
            SupplyPower();
        }
    }

    void SupplyPower()
    {
        if (!isOn) return;

        // 전기 공급 범위 내의 오브젝트 탐색
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, PowerRange, powerableLayer);

        foreach (Collider obj in objectsInRange)
        {
            // 탐지된 오브젝트에서 IPowerable 인터페이스를 구현한 객체에 전력 공급
            IPowerable powerable = obj.GetComponent<IPowerable>();
            if (powerable != null)
            {
                powerable.ProvidePower(MaxPower);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, PowerRange);
    }
}