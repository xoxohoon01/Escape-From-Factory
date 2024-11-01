using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{
    public Condition mainBoard;
    public Condition memory;
    public Condition clock;

    [SerializeField] private Image mainBoardBar;
    [SerializeField] private Image memoryBar;
    [SerializeField] private Image clockBar;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }

    private void Update()
    {
        mainBoardBar.fillAmount = mainBoard.GetPercentage();
        memoryBar.fillAmount = memory.GetPercentage();
        clockBar.fillAmount = clock.GetPercentage();
    }
}
