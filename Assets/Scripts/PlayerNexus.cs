using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNexus : MonoBehaviour
{
    public PlayerStats PlayerStats;

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy")
        {
            PlayerStats.takeDamage(10);
            Destroy(enemy.gameObject);
        }
    }
}
