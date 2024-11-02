using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    private Condition HP { get { return uiCondition.HP; } } // MainBoard
    private Condition Hunger { get { return uiCondition.Hunger; } } // Memory
    private Condition Stamina { get { return uiCondition.Stamina; } } // Clock

    [SerializeField] private float noHungerHPDecay;

    private void Update()
    {
        Hunger.Subtract(Hunger.passiveValue * Time.deltaTime);
        Stamina.Add(Stamina.passiveValue * Time.deltaTime);

        if (Hunger.curValue <= 0)
        {
            HP.Subtract(noHungerHPDecay * Time.deltaTime);
        }

        if (HP.curValue <= 0)
        {
            Die();
        }
    }

    public void HealHP(float amount)
    {
        HP.Add(amount);
    }

    public void HealHunger(float amount)
    {
        Hunger.Add(amount);
    }


    public void Die()
    {
        Debug.Log("Die");
        Time.timeScale = 0;
    }

}
