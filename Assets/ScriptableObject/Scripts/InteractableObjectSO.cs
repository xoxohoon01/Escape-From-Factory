using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObjectSO", menuName = "ScriptableObject/InteractableObjectSO", order = 1)]
public class InteractableObjectSO : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    public bool isCunstructible;
    public Sprite icon;
    public GameObject prefab;
}
