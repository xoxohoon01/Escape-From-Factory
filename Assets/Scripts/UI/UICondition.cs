using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{
    public Condition HP; // MainBoard
    public Condition Hunger; // Memory
    public Condition Stamina; // Clock

    [SerializeField] private Image HPBar;
    [SerializeField] private Image HungerBar;
    [SerializeField] private Image StaminaBar;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }

    private void Update()
    {
        HPBar.fillAmount = HP.GetPercentage();
        HungerBar.fillAmount = Hunger.GetPercentage();
        StaminaBar.fillAmount = Stamina.GetPercentage();
    }
}
