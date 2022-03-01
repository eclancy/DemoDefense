using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D EnemyBody;
    private string CurrentDirection;
    private int MovementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBody = gameObject.GetComponent<Rigidbody2D>();
        //Vector3 TargetPosition = new Vector3(-4.5f,-0.5f,0);

        //EnemyBody.MovePosition(transform.position + TargetPosition * MovementSpeed * Time.deltaTime);
        //Move("Right");
    }

    // Update is called once per frame
    void Update()
    {
        double XLocation = EnemyBody.position.x;
        
        //Vector3 TargetPosition = new Vector3(-4.5f,-0.5f,0);

        Vector3 TargetPosition = new Vector3(1f,0,0);

        EnemyBody.MovePosition((transform.position + TargetPosition) * 1 * Time.deltaTime);

       // if(XLocation > 0 && CurrentDirection != "Up")
       // { Move("Up"); }

        int a = 1;
        //Move();
    }

    //Path 3 right, 3 up, 3 right, 4 down, 4 right, 2 up, 6 right
    // -4.5, -0.5
    void Move(string Direction)
    {
        CurrentDirection = Direction;
        EnemyBody.MovePosition(new Vector3(-4.5f,-0.5f,0));
        if(Direction == "Right")
        { EnemyBody.AddForce(new Vector2(MovementSpeed, 0), ForceMode2D.Impulse); }
        if(Direction == "Left")
        { EnemyBody.AddForce(new Vector2((MovementSpeed * -1), 0), ForceMode2D.Impulse); }
        if(Direction == "Up")
        { EnemyBody.AddForce(new Vector2(0, MovementSpeed), ForceMode2D.Impulse); }
        if(Direction == "Down")
        { EnemyBody.AddForce(new Vector2(0, (MovementSpeed * -1)), ForceMode2D.Impulse); }
    }
}
