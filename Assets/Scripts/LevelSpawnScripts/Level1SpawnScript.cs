using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SpawnScript : MonoBehaviour
{
    public Spawner Spawner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLevel1Waves());
    }

    IEnumerator SpawnLevel1Waves()
    {
        Spawner.Spawn(SpawnName:"BasicEnemy", SpawnCount:4, SpawnDelay: 0.5f);
        yield return new WaitForSeconds(3f);
        Spawner.Spawn(SpawnName:"BasicEnemy", SpawnCount:11, SpawnDelay: 0.2f);
        yield return new WaitForSeconds(3.5f);
        Spawner.Spawn(SpawnName:"BasicEnemy", SpawnCount:16, SpawnDelay: 0.1f);
    }

}
