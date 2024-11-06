using UnityEngine;

public class Object : MonoBehaviour
{
    public InteractableObjectSO objectSO;
    public ItemData itemData;
    public void TakeDamage(float damage)
    {
        float dur = objectSO.durability;
        dur -= damage;

        if(dur <= 0)
        {
            DestroyObject();
        } 
    }

    public virtual void DestroyObject()
    {    
        //TODO 오브젝트풀 적용 밑 파괴 효과 적용
        Destroy(gameObject);
    }
}
