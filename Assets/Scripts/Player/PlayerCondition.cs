using System;
using UnityEngine;

public class PlayerCondition : Unit
{
    public UICondition uiCondition;

    public Condition mainBoard;
    public Condition memory;
    public Condition clock;

    public event Action onMainBoardChanged;
    public event Action onMemoryChanged;
    public event Action onClockChanged;

    [SerializeField] private float noMemoryMainBoardDecay;

    private void Update()
    {
        memory.Subtract(memory.passiveValue * Time.deltaTime);
        onMemoryChanged?.Invoke();
        clock.Add(clock.passiveValue * Time.deltaTime);
        onClockChanged?.Invoke();

        if (memory.curValue <= 0)
        {
            mainBoard.Subtract(noMemoryMainBoardDecay * Time.deltaTime);
            onClockChanged?.Invoke();
        }
    }

    public override void Ondamage(float damage)
    {
        mainBoard.Subtract(damage);
        onMainBoardChanged?.Invoke();
        if (mainBoard.curValue <= 0)
        {
            Die();
        }
    }

    public void HealMainBoard(float amount)
    {
        mainBoard.Add(amount);
        onMainBoardChanged?.Invoke();
    }

    public void HealMemory(float amount)
    {
        memory.Add(amount);
        onMemoryChanged?.Invoke();
    }


    public void Die()
    {
        Debug.Log("Die");
        Time.timeScale = 0;
    }




}
