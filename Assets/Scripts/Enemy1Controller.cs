using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D EnemyBody;
    private string CurrentDirection;
    private int PathStep = 0;
    private int MovementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBody = gameObject.GetComponent<Rigidbody2D>();

        Move("Right");
    }

    // Update is called once per frame
    void Update()
    {
        double XLocation = EnemyBody.position.x;
        double YLocation = EnemyBody.position.y;

        if(XLocation > -4.45 && PathStep == 0)
        { Move("Up"); PathStep = 1; }
        else if(YLocation > 2.5 && PathStep == 1)
        { Move("Right"); PathStep = 2; }
        else if(XLocation > -1.5 && PathStep == 2)
        { Move("Down"); PathStep = 3; }
        else if (YLocation > -1.5 && PathStep == 3)
        { Move("Right"); PathStep = 4; }


    }

    //Path 3 right, 3 up, 3 right, 4 down, 4 right, 2 up, 6 right
    // -4.5, -0.5
    // -4.5, 2.5
    // -1.5, 2.5
    // -1.5, -1.5
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
}
