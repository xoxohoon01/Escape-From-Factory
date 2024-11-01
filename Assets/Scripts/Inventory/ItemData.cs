using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int ID;
    public string Name;
    public string Description;

    public ItemData(int _ID = 0, string _Name = "", string _Description = "")
    {
        ID = _ID;
        Name = _Name;
        Description = _Description;
    }
}
