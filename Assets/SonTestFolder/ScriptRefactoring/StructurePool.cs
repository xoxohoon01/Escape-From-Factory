using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePool : MonoBehaviour
{
    private List<GameObject> pool;

    public void InitializedPool(int poolCount)
    {
        pool = new List<GameObject>(new GameObject[poolCount]);
    }

    public GameObject GetObject(InteractableObjectSO objectSO, int index)
    {
        if (pool[index] == null)
        {
            GameObject newObj = Instantiate(objectSO.prefab);
            newObj.transform.SetParent(transform);

            pool[index] = newObj;
            newObj.SetActive(true);
            return newObj;
        }
        else
        {
            GameObject obj = pool[index];
            obj.SetActive(true);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
