using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BuildUIDataSO", menuName = "ScriptableObject/BuildUIDataSO", order = 4)]
public class BuildUIDataSO : ScriptableObject
{
    [Header("Info")]
    [SerializeField]
    public List<InteractableObjectSO> selectableObjects = new List<InteractableObjectSO>();
    public Sprite menuSprite;

    public UnityAction<int> OnSelectedEvent;

    public void RaiseSelectEvent(int _index)
    {
        OnSelectedEvent?.Invoke(_index);
    }
}
