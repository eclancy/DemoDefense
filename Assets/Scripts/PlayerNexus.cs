using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNexus : MonoBehaviour
{
    public PlayerStats PlayerStats;

    private void OnTriggerEnter(Collider enemy)
    {
        Debug.Log("ahh");
        Debug.Log(enemy);
        // if (enemy.tag == "Enemy")
        // {
        //     PlayerStats.takeDamage(10);
        //     Destroy(enemy.gameObject);
        // }
    }
}
