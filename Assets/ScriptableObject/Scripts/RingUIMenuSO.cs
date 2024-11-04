using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum MenuType
    {
        Build,
        Move,
        Remove
    }

[CreateAssetMenu(fileName = "RingUIMenuSO", menuName = "ScriptableObject/RingUIMenuSO", order = 3)]
public class RingUIMenuSO : ScriptableObject
{

    [Header("Info")]
    public string Name;
    public string Description;
    public Sprite icon;
    public MenuType menuType;
}