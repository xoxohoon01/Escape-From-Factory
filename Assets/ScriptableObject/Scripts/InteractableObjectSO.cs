using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Resource,
    Weapon
}

[CreateAssetMenu(fileName = "InteractableObjectSO", menuName = "ScriptableObject/InteractableObjectSO", order = 1)]
public class InteractableObjectSO : ScriptableObject
{
    [Header("Info")]
    public int ID;
    public string Name;
    public string Description;
    public bool isCunstructible;
    public int MaxCount;
    public float durability;
    public Sprite icon;
    public GameObject prefab;
    public ItemType Type;
    public GameObject equipPrefab;
    
}
