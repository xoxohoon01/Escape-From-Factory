using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public List<Transform> SpawnPoints;
    public List<GameObject> SpawnObject;

    public float SpawnDelay;

    public void Start()
    {
        StartCoroutine(CoSpawnObject());
    }

    public IEnumerator CoSpawnObject()
    {
        while (true)
        {
            int spawnIndex = Random.Range(0, SpawnPoints.Count);
            int SpawnObjectIndex = Random.Range(0, SpawnObject.Count);

            Instantiate(SpawnObject[SpawnObjectIndex], SpawnPoints[spawnIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
