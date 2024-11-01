using UnityEngine;

public class PlayerCondition : Unit
{
    public UICondition uiCondition;

    private Condition mainBoard { get { return uiCondition.mainBoard; } } //health
    private Condition memory { get { return uiCondition.memory; } } // hunger
    private Condition clock { get { return uiCondition.clock; } } //stamina

    [SerializeField] private float noMemoryMainBoardDecay;

    private void Update()
    {
        memory.Subtract(memory.passiveValue * Time.deltaTime);
        clock.Add(clock.passiveValue * Time.deltaTime);

        if (memory.curValue <= 0)
        {
            mainBoard.Subtract(noMemoryMainBoardDecay * Time.deltaTime);
        }
    }

    public override void Ondamage(float damage)
    {
        mainBoard.Subtract(damage);
        if (mainBoard.curValue <= 0)
        {
            Die();
        }
    }

    public void HealMainBoard(float amount)
    {
        mainBoard.Add(amount);
    }

    public void HealMemory(float amount)
    {
        memory.Add(amount);
    }


    public void Die()
    {
        Debug.Log("Die");
        Time.timeScale = 0;
    }




}
