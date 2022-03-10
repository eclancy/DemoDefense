using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    private Transform SpawnerBody;
    private int EnemySpawnCount;
    private int EnemySpawnTarget = 0;

    void Start()
    {
        SpawnerBody = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if(EnemySpawnCount >= EnemySpawnTarget)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    public void Spawn(string SpawnName, int SpawnCount, float SpawnDelay)
    {
        if(SpawnName == "BasicEnemy")
        {
            EnemySpawnTarget = SpawnCount;
            InvokeRepeating("SpawnEnemy", 1, SpawnDelay);
        }

    }

    public void SpawnEnemy()
    {
        Instantiate(BasicEnemyPrefab, SpawnerBody.position, Quaternion.identity, SpawnerBody);
        EnemySpawnCount++;
    }

}
