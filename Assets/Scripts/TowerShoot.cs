using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject[] enemies;
    AudioSource audioData;

    void Start()
    {
        InvokeRepeating("destroy", 3, 3);
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    void destroy()
    {
        audioData.Play(0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if ( Vector3.Distance(gameObject.transform.position, enemy.transform.position) < 5 )
            {
                Destroy (enemy);
            }
        }
    }
}

