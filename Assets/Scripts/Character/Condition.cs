using UnityEngine;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float passiveValue;
    [SerializeField] private float maxVaule;
    [SerializeField] private float startValue;

    private void Start()
    {
        curValue = startValue;
    }

    public float GetPercentage()
    {
        return curValue / maxVaule;
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxVaule);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0);
    }
}
