using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quake : MonoBehaviour
{
    public GameObject[] enemies;
    AudioSource audioData;

    void Start()
    {
        // Find the tiles grid game object, access the script to get where
        // this gameobject is located, get all adjacent tiles?

        InvokeRepeating("AttackEnemies", 3, 3);
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    void AttackEnemies()
    {
        StartCoroutine(playAttackAnimation());
        audioData.Play(0);
 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if ( Vector3.Distance(gameObject.transform.position, enemy.transform.position) < 10 )
            {
                Enemy1Controller enemyScript = (Enemy1Controller) enemy.GetComponent(typeof(Enemy1Controller));
                enemyScript.TakeDamage("Earth", 20);
            }
        }
    }

    IEnumerator playAttackAnimation(){
        GetComponent<ParticleSystem>().Play(true);
        yield return new WaitForSeconds(0.2f);
        GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
    
}

