public class Battery : Object, IInteractable ,IUseable
{
    public ItemData itemdata;

    public bool IsObtainable()
    {
        return true;
    }
    public void Interact()
    {
        Destroy(this);
    }

    public void UseItem()
    {

    }
}
