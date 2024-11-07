using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemData
{
    public InteractableObjectSO Item { get; private set; }
    public int Stack;

    public ItemData(InteractableObjectSO item)
    {
        Item = item;
        Stack = 1;
    }
}
