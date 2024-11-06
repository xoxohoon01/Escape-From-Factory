using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ObtainableObjectSO", menuName = "ScriptableObject/ObtainableObjectSO", order = 0)]
public class ObtainableObjectSO : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    public ItemType itemType;
    public Sprite icon;
    public GameObject prefab;
    public bool canStack;
    public int maxStackAmount;
}
