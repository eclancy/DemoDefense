using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SpawnScript : MonoBehaviour
{
    public Spawner Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.Spawn(SpawnName:"BasicEnemy", SpawnCount:5, SpawnDelay: 1);
    }

}
