using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    public enum EnemyDirection
    {
        Undefined = 0,
        ThirtyDegrees = 1,
        SixtyDegrees = 2,
        OneTwentyDegrees = 3,
        OneFiftyDegrees = 4,
        TwoTenDegrees = 5,
        TwoFortyDegrees = 6,
        ThreeHundoDegrees = 7,
        ThreeThirtyDegrees = 8,
    }

    private int moveSpeed = 2;
    private EnemyDirection enemyDirection = EnemyDirection.Undefined;
    Vector2 velocity;
    Vector2 direction;
    private bool firstFuelPickedUp = false;

    private void Start()
    {
        enemyDirection = (EnemyDirection)Random.Range(1, 9);
        var dir = DefineDirection();
        direction = new Vector2(dir.Item1, dir.Item2);        
        GameEvents.Current.OnPlayerFuelPickup += OnPlayerFuelPickup;
    }

    private Tuple<float, float> DefineDirection()
    {
        Tuple<float, float> direction = new Tuple<float, float>(0.5f, 0.866f);
        switch(enemyDirection)
        {
            case EnemyDirection.ThirtyDegrees:
                direction = new Tuple<float, float>(0.5f, 0.866f);
                break;
            case EnemyDirection.SixtyDegrees:
                direction = new Tuple<float, float>(0.866f, 0.5f);
                break;
            case EnemyDirection.OneTwentyDegrees:
                direction = new Tuple<float, float>(0.5f, -0.866f);
                break;
            case EnemyDirection.OneFiftyDegrees:
                direction = new Tuple<float, float>(0.866f, -0.5f);
                break;
            case EnemyDirection.TwoTenDegrees:
                direction = new Tuple<float, float>(-0.5f, -0.866f);
                break;
            case EnemyDirection.TwoFortyDegrees:
                direction = new Tuple<float, float>(-0.866f, -0.5f);
                break;
            case EnemyDirection.ThreeHundoDegrees:
                direction = new Tuple<float, float>(-0.5f, 0.866f);
                break;
            case EnemyDirection.ThreeThirtyDegrees:
                direction = new Tuple<float, float>(-0.866f, 0.5f);
                break;
        }

        return direction;
    }

    private void Update()
    {
        if (firstFuelPickedUp)
        {
            velocity = moveSpeed * direction;
            transform.Translate(Time.deltaTime * velocity, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name == "LeftWall" || col.gameObject.name == "RightWall")
        {
            direction.x *= -1;
        }

        if (col.gameObject.name == "TopWall" || col.gameObject.name == "BottomWall")
        {
            direction.y *= -1;
        }

        velocity = direction * moveSpeed;
    }

    private void OnPlayerFuelPickup()
    {
        if (firstFuelPickedUp && moveSpeed < 25)
        {
            moveSpeed += 1;
        }
        else
        {
            firstFuelPickedUp = true;
        }
    }
}
