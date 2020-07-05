﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehavior : MonoBehaviour
{
    private float x = 0;
    private float y = 0;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-3, 3);    
        y = Random.Range(-2, 2); 
        transform.position = new Vector2(x, y);  
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Player")
        {   
            x = Random.Range(-3, 3);    
            y = Random.Range(-2, 2); 
            transform.position = new Vector2(x, y); 

            GameEvents.Current.PlayerFuelPickup();
        }

        if (col.gameObject.name == "Enemy")
        {
            x = Random.Range(-3, 3);    
            y = Random.Range(-2, 2); 
            transform.position = new Vector2(x, y); 

            GameEvents.Current.EnemyFuelPickup();
        }
    }
}
