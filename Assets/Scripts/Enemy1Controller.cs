using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private string CurrentDirection;

    private int PathStep = 1;

    private float MovementSpeed = 10;

    private double MaxHealth = 100;

    public double CurrentHealth = 100;

    private Transform[] waypoints;

    private Transform targetWaypoint;

    void Start()
    {
        this.rigidBody = gameObject.GetComponent<Rigidbody2D>();

        waypoints = transform.parent.GetComponent<WaypointReference>().GetWaypoints();
        targetWaypoint = waypoints[PathStep];
        Move();

        Debug.Log (targetWaypoint);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetWaypoint.transform.position) < 0.1f ){
            PathStep++;
            targetWaypoint = waypoints[PathStep];
            Debug.Log (targetWaypoint);
            Move();
        }
    }

    void Move()
    {
        //reset the velocity
        rigidBody.velocity = new Vector2(0, 0);

        // rigidBody.AddForce( (targetWaypoint.transform.position - transform.position) * MovementSpeed, ForceMode2D.Impulse );
        string Direction;
        float xDistance =
            targetWaypoint.transform.position.x - transform.position.x;
        float yDistance =
            targetWaypoint.transform.position.y - transform.position.y;

        //x distance is greater, figure out if we should move left or right
        if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
        {
            if (xDistance > 0){
                Direction = "Right";
            }
            else{
                Direction = "Left";
            }
        }
        else
        //y distance is greater, figure out if we should move up or down
        {
            if (yDistance > 0) {
                Direction = "Up";
            }
            else {
                Direction = "Down";
            }
        }

        if (Direction == "Right")
        {
            rigidBody
                .AddForce(new Vector2(MovementSpeed, 0), ForceMode2D.Impulse);
        }
        if (Direction == "Left")
        {
            rigidBody
                .AddForce(new Vector2((MovementSpeed * -1), 0),
                ForceMode2D.Impulse);
        }
        if (Direction == "Up")
        {
            rigidBody
                .AddForce(new Vector2(0, MovementSpeed), ForceMode2D.Impulse);
        }
        if (Direction == "Down")
        {
            rigidBody
                .AddForce(new Vector2(0, (MovementSpeed * -1)),
                ForceMode2D.Impulse);
        }
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
