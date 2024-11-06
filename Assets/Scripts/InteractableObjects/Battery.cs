public class Battery : Object, IInteractable ,IUseable
{

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
