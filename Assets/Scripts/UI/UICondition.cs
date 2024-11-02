using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{

    private PlayerCondition condition;
    private Condition mainBoard { get { return condition.mainBoard; } } //health
    private Condition memory { get { return condition.memory; } } // hunger
    private Condition clock { get { return condition.clock; } } //stamina

    [SerializeField] private Image mainBoardBar;
    [SerializeField] private Image memoryBar;
    [SerializeField] private Image clockBar;

    private void Start()
    {
        condition = CharacterManager.Instance.Player.condition;
        condition.uiCondition = this;

        condition.onMainBoardChanged += UpdateMainBoardBar;
        condition.onMemoryChanged += UpdateMemoryBar;
        condition.onClockChanged += UpdateClockBar;
    }

    private void UpdateMainBoardBar()
    {
        mainBoardBar.fillAmount = mainBoard.GetPercentage();
    }

    private void UpdateMemoryBar()
    {
        memoryBar.fillAmount = memory.GetPercentage();
    }

    private void UpdateClockBar()
    {
        clockBar.fillAmount = clock.GetPercentage();
    }
}
