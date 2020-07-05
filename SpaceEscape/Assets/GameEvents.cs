using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current { get; private set; }

    private void Awake() 
    {
        Current = this;   
    }
    
    public event Action OnPlayerFuelPickup;
    public event Action OnPlayerItemPickup;
    public event Action OnEnemyFuelPickup;
    public event Action OnEnemyItemPickup;

    public void PlayerFuelPickup()
    {
        if(OnPlayerFuelPickup != null)
        {
            OnPlayerFuelPickup();
        }
    }

    public void PlayerItemPickup()
    {
        if(OnPlayerItemPickup != null)
        {
            OnPlayerItemPickup();
        }
    }

    public void EnemyFuelPickup()
    {
        if(OnEnemyFuelPickup != null)
        {
            OnEnemyFuelPickup();
        }
    }

    public void EnemyItemPickup()
    {
        if(OnEnemyItemPickup != null)
        {
            OnEnemyItemPickup();
        }
    }
}
