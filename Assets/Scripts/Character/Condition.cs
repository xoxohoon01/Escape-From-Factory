using UnityEngine;

[System.Serializable]
public class Condition
{
    public float curValue;
    public float passiveValue;
    [SerializeField] private float maxVaule;
    [SerializeField] private float startValue;

    public Condition(float hp = 0)
    {
        maxValue = hp;
        startValue = hp;
        curValue = startValue;
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0);
    }
}
