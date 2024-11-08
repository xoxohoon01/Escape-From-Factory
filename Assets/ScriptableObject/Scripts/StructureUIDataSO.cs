using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StructureUIDataSO", menuName = "ScriptableObject/StructureUIDataSO", order = 2)]
public class StructureUIDataSO : ScriptableObject
{
    [Header("Info")]
    [SerializeField]
    public List<RingUIMenuSO> selectableMenus = new List<RingUIMenuSO>();
    public Sprite menuSprite;

    public UnityAction OnObjectMoveEvent;
    public UnityAction OnObjectDestroyEvent;

    public void RaiseMoveEvent()
    {
        OnObjectMoveEvent?.Invoke();
    }

    public void RaiseDestroyEvent()
    {
        OnObjectDestroyEvent?.Invoke();
    }
}
