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
    public event Action<ItemBehavior> OnPlayerItemPickup;
    public event Action OnEnemyFuelPickup;
    public event Action OnEnemyItemPickup;
    public event Action OnGameOver;
    public event Action OnPaused;

    public void PlayerFuelPickup()
    {
        if(OnPlayerFuelPickup != null)
        {
            OnPlayerFuelPickup();
        }
    }

    public void PlayerItemPickup(ItemBehavior item)
    {
        if(OnPlayerItemPickup != null)
        {
            OnPlayerItemPickup(item);
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

    public void GameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public void Pause()
    {
        if (OnPaused != null)
        {
            OnPaused();
        }
    }
}
