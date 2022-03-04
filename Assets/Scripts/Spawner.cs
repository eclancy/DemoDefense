using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CircleEnemyPrefab;
    private Transform SpawnerBody;
    private int CircleSpawnCount;
    private int CircleSpawnTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnerBody = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CircleSpawnCount >= CircleSpawnTarget)
        {
            CancelInvoke("SpawnCircle");
        }
    }

    public void Spawn(string SpawnName, int SpawnCount, float SpawnDelay)
    {
        if(SpawnName == "Circle")
        {
            CircleSpawnTarget = SpawnCount;
            InvokeRepeating("SpawnCircle", 1, SpawnDelay);
        }

    }

    public void SpawnCircle()
    {
        Instantiate(CircleEnemyPrefab, SpawnerBody.position, Quaternion.identity);
        CircleSpawnCount++;
    }

}
