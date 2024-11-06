
public class ObtaineableItem : InteractableObject, IInteractable
{
    public bool IsObtainable()
    {
        return true;
    }
    public void Interact()
    {
        Destroy(gameObject);
    }

    //public void UseItem()
    //{
    //    // 인벤토리에서 직접 사용하지 않을경우 
    //    PlayerCondition player = new PlayerCondition();
    //    if (Type == ConsumableType.Battery)
    //    {
    //        player.HealHP(HealAmount);
    //    }
    //    else
    //    {
    //        player.HealHunger(HealAmount);
    //    }
    //}
}
