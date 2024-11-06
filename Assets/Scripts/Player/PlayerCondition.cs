using System;
using UnityEngine;

public class PlayerCondition : Unit
{
    public UICondition uiCondition;

    public Condition HP; // Mainboard
    public Condition Hunger; //Memory
    public Condition Stamina; //Clock

    public event Action onHPChanged;
    public event Action onHungerChanged;
    public event Action onStaminaChanged;

    [SerializeField] private float noHungerHPDecay;

    private void Update()
    {
        Hunger.Subtract(Hunger.passiveValue * Time.deltaTime);
        onHungerChanged?.Invoke();
        Stamina.Add(Stamina.passiveValue * Time.deltaTime);
        onStaminaChanged?.Invoke();

        if (Hunger.curValue <= 0)
        {
            HP.Subtract(noHungerHPDecay * Time.deltaTime);
            onStaminaChanged?.Invoke();
        }
    }

    public override void Ondamage(float damage)
    {
        HP.Subtract(damage);
        onHPChanged?.Invoke();
        if (HP.curValue <= 0)
        {
            Die();
        }
    }

    public void HealHP(float amount)
    {
        HP.Add(amount);
        onHPChanged?.Invoke();
    }

    public void SubtractHP(float amount)
    {
        HP.Subtract(amount);
        onHPChanged?.Invoke();
    }

    public void HealHunger(float amount)
    {
        Hunger.Add(amount);
        onHungerChanged?.Invoke();
    }

    public void SubtractHunger(float amount)
    {
        Hunger.Subtract(amount);
        onHungerChanged?.Invoke();
    }

    public void Die()
    {
        Debug.Log("Die");
        Time.timeScale = 0;
    }




}
