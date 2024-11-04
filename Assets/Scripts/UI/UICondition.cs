using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{

    private PlayerCondition condition;
    private Condition HP { get { return condition.HP; } } //health
    private Condition Hunger { get { return condition.Hunger; } } // hunger
    private Condition Stamina { get { return condition.Stamina; } } //stamina

    [SerializeField] private Image HPBar;
    [SerializeField] private Image HungerBar;
    [SerializeField] private Image StaminaBar;

    private void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        condition.uiCondition = this;

        condition.onHPChanged += UpdateHPBar;
        condition.onHungerChanged += UpdateHungerBar;
        condition.onStaminaChanged += UpdateStaminaBar;
    }

    private void UpdateHPBar()
    {
        HPBar.fillAmount = HP.GetPercentage();
    }

    private void UpdateHungerBar()
    {
        HungerBar.fillAmount = Hunger.GetPercentage();
    }

    private void UpdateStaminaBar()
    {
        StaminaBar.fillAmount = Stamina.GetPercentage();
    }
}
