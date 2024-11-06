public enum MaterailType
{
    Wood,
    Iron,
}
public class Material : Object, IInteractable
{
    public MaterailType type;
    public bool IsObtainable()
    {
        return true;
    }
    public void Interact()
    {
        // TODO : 인벤토리에 들어가기
    }
}