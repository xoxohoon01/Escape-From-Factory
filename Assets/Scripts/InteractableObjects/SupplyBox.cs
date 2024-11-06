using System.Collections.Generic;
using UnityEngine;

public class SupplyBox : InteractableObject
{
    public List<GameObject> Supplys;
    public override void DestroyObject()
    {
        int num = Random.Range(0, Supplys.Count);
        Instantiate(Supplys[num], this.transform);
        DestroyObject();
    }
}
