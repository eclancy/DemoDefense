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

    // Start is called before the first frame update
    void Start()
    {
        EnemyBody = gameObject.GetComponent<Rigidbody2D>();
        Move("Right");
    }

    private void OnTriggerEnter(Collider enemy)
    {
        print(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        double XLocation = EnemyBody.position.x;
        double YLocation = EnemyBody.position.y;

        if(XLocation > -4.55 && PathStep == 0)
        { Move("Up"); PathStep = 1; }
        else if(YLocation > 2.5 && PathStep == 1)
        { Move("Right"); PathStep = 2; }
        else if(XLocation > -1.55 && PathStep == 2)
        { Move("Down"); PathStep = 3; }
        else if (YLocation < -1.5 && PathStep == 3)
        { Move("Right"); PathStep = 4; }
        else if (XLocation > 2.5 && PathStep == 4)
        { Move("Up"); PathStep = 5; }
        else if (YLocation > 0.5 && PathStep == 5)
        { Move("Right"); PathStep = 6; }
        else if (XLocation > 9.0 && PathStep == 6)
        { Move("Stop"); PathStep = 7; }
    }
    //Map One Pathing Cords
    // -4.5, -0.5
    // -4.5, 2.5
    // -1.5, 2.5
    // -1.5, -1.5
    // 2.5, -1.5
    // 2.5, 0.5
    // 9.0, 0.5

    void Move(string Direction)
    {
        CurrentDirection = Direction;
        EnemyBody.velocity = new Vector2(0, 0);
        if (Direction == "Right")
        { EnemyBody.AddForce(new Vector2(MovementSpeed, 0), ForceMode2D.Impulse); }
        if(Direction == "Left")
        { EnemyBody.AddForce(new Vector2((MovementSpeed * -1), 0), ForceMode2D.Impulse); }
        if(Direction == "Up")
        { EnemyBody.AddForce(new Vector2(0, MovementSpeed), ForceMode2D.Impulse); }
        if(Direction == "Down")
        { EnemyBody.AddForce(new Vector2(0, (MovementSpeed * -1)), ForceMode2D.Impulse); }
    }

    public void TakeDamage(string DamageType, double DamageAmount)
    {
        if(DamageType == "Fire") { CurrentHealth = CurrentHealth - (DamageAmount*1.5); }
        else { CurrentHealth = CurrentHealth - DamageAmount; }

        if(CurrentHealth <= 0) 
        { 
            Destroy(gameObject); 
        }
        else
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            float Transparency = ((1 / (float)MaxHealth) * (float)CurrentHealth);
            tmp.a = Transparency;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}
