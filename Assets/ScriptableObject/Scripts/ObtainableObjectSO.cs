using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Resource
}

[CreateAssetMenu(fileName = "ObtainableObjectSO", menuName = "ScriptableObject/ObtainableObjectSO", order = 0)]
public class ObtainableObjectSO : ScriptableObject
{
    [Header("Info")]
    public string objectName;
    public string objectDescription;
    public ItemType itemType;
    public Sprite icon;
    public GameObject prefab;
    public bool canStack;
    public int maxStackAmount;
}
