using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D EnemyBody;

    private string CurrentDirection;

    private int PathStep = 0;

    private int MovementSpeed = 10;

    private double MaxHealth = 100;

    public double CurrentHealth = 100;

    private GameObject[] waypoints;

    private GameObject targetWaypoint;

    void Start()
    {
        Debug.Log(transform.parent.GetComponent<WaypointReference>().GetWaypoints());
        // waypoints = gameObject.transform.parent.GetComponent<GetWaypoints>();
        // targetWaypoint = waypoints[0];
        Debug.Log (waypoints);
    }

    void Update()
    {
                Debug.Log(transform.parent.GetComponent<WaypointReference>().GetWaypoints());

        // if (transform.position == targetWaypoint.position)
        // {
        //     //update target
        //     Move ();
        // }
    }

    void Move()
    {
        EnemyBody.velocity = new Vector2(0, 0);
        // GetComponent<Rigidbody>()
        //     .AddForce((targetWaypoint.transform.position - transform.position) *
        //     MovementSpeed);
    }

    public void TakeDamage(string DamageType, double DamageAmount)
    {
        if (DamageType == "Fire")
        {
            CurrentHealth = CurrentHealth - (DamageAmount * 1.5);
        }
        else
        {
            CurrentHealth = CurrentHealth - DamageAmount;
        }

        if (CurrentHealth <= 0)
        {
            Destroy (gameObject);
        }
        else
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            float Transparency =
                ((1 / (float) MaxHealth) * (float) CurrentHealth);
            tmp.a = Transparency;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}
