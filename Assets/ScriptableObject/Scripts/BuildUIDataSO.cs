using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildUIDataSO", menuName = "ScriptableObject/BuildUIDataSO", order = 4)]
public class BuildUIDataSO : ScriptableObject
{
    [Header("Info")]
    [SerializeField]
    public List<InteractableObjectSO> selectableObjects = new List<InteractableObjectSO>();
    public Sprite menuSprite;
}
